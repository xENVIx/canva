using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace canva
{
    internal class CustomIcon
    {
        internal static CustomIcon Instance { get { return _instance; } }

        private CustomIcon()
        {

        }




        internal Cursor LoadCustomCursor(String resourceName, int xHotSpot, int yHotSpot)
        {

            var asm = Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    MessageBox.Show("Couldn't find embedded PNG resource.");
                    throw new ArgumentNullException("Stream is null");
                }

                using (var bmp = new Bitmap(stream))
                {
                    return CreateCursorFromBitmap(bmp, xHotSpot, yHotSpot); // Adjust hotspot to match your design
                }
            }

        }

        private static CustomIcon _instance = new CustomIcon();





        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [DllImport("user32.dll")]
        static extern IntPtr CreateIconIndirect(ref ICONINFO icon);

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        public Cursor CreateCursorFromBitmap(Bitmap bmp, int xHotspot, int yHotspot)
        {
            var icon = new ICONINFO();
            icon.fIcon = false;
            icon.xHotspot = xHotspot;
            icon.yHotspot = yHotspot;
            icon.hbmColor = bmp.GetHbitmap(Color.FromArgb(0, 0, 0, 0)); // Preserve alpha
            icon.hbmMask = bmp.GetHbitmap(); // Not ideal, but gets around some bugs

            IntPtr ptr = CreateIconIndirect(ref icon);
            return new Cursor(ptr);
        }

    }
}
