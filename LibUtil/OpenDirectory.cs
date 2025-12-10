using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibUtil
{
    public static class DirectoryUtl
    {

        public static bool OpenDirectory(String dir, String file = "")
        {
            bool ret = true;

            try
            {
                if (file == "")
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments = dir,
                        UseShellExecute = true
                    };

                    Process.Start(psi);

                }
                else
                {
                    String args = $@"/select, ""{Path.Combine(dir, file)}""";
                    var psi = new ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments = args,
                        UseShellExecute = true
                    };

                    Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                //Logger.Logger.MainLog.LOG(ex);
                ret = false;
            }

            return ret;

        }

    }
}
