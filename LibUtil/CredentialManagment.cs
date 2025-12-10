using System;
using System.Runtime.InteropServices;
using System.Text;

public static class WindowsCredentialManager
{
    public static bool SaveCredential(string target, string username, string secret)
    {
        var byteArray = Encoding.Unicode.GetBytes(secret);

        var credential = new CREDENTIAL
        {
            Type = CRED_TYPE.GENERIC,
            TargetName = target,
            CredentialBlob = Marshal.StringToCoTaskMemUni(secret),
            CredentialBlobSize = (uint)byteArray.Length,
            Persist = (uint)CRED_PERSIST.LOCAL_MACHINE,
            AttributeCount = 0,
            UserName = username
        };

        bool result = CredWrite(ref credential, 0);
        Marshal.FreeCoTaskMem(credential.CredentialBlob);
        return result;
    }

    public static (string Username, string Password)? GetCredential(string target)
    {
        bool result = CredRead(target, CRED_TYPE.GENERIC, 0, out IntPtr credPtr);

        if (!result || credPtr == IntPtr.Zero)
            return null;

        using (CriticalCredentialHandle critCred = new(credPtr))
        {
            var cred = critCred.GetCredential();
            string password = Marshal.PtrToStringUni(cred.CredentialBlob, (int)cred.CredentialBlobSize / 2);
            return (cred.UserName, password);
        }
    }

    public static void DeleteCredential(string target)
    {
        CredDelete(target, CRED_TYPE.GENERIC, 0);
    }

    #region Interop Definitions

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct CREDENTIAL
    {
        public uint Flags;
        public CRED_TYPE Type;
        public string TargetName;
        public string Comment;
        public System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
        public uint CredentialBlobSize;
        public IntPtr CredentialBlob;
        public uint Persist;
        public uint AttributeCount;
        public IntPtr Attributes;
        public string TargetAlias;
        public string UserName;
    }

    private enum CRED_TYPE : uint
    {
        GENERIC = 1,
    }

    private enum CRED_PERSIST : uint
    {
        SESSION = 1,
        LOCAL_MACHINE = 2,
        ENTERPRISE = 3
    }

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool CredWrite([In] ref CREDENTIAL userCredential, [In] uint flags);

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool CredRead(string target, CRED_TYPE type, int reservedFlag, out IntPtr credentialPtr);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool CredFree([In] IntPtr buffer);

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool CredDelete(string target, CRED_TYPE type, uint flags);

    private sealed class CriticalCredentialHandle : IDisposable
    {
        private IntPtr handle;
        public CriticalCredentialHandle(IntPtr handle) => this.handle = handle;
        public CREDENTIAL GetCredential() => (CREDENTIAL)Marshal.PtrToStructure(handle, typeof(CREDENTIAL));
        public void Dispose()
        {
            if (handle != IntPtr.Zero)
            {
                CredFree(handle);
                handle = IntPtr.Zero;
            }
        }
    }

    #endregion
}