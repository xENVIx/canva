using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    internal class CustomCursor
    {
        internal static CustomCursor Instance { get { return _instance; } }

        public Cursor DripperTool { get { if (_dripperTool == null) return Cursors.Default; return _dripperTool; } }


        private CustomCursor()
        {
            _dripperTool = LoadCustomCursor("canva.Icons.drip_drip_4.png", 5, 25);

        }




        internal Cursor LoadCustomCursor(string resourceName, int xHotSpot, int yHotSpot)
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


        private Cursor _dripperTool;

        private static CustomCursor _instance = new CustomCursor();





        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public nint hbmMask;
            public nint hbmColor;
        }

        [DllImport("user32.dll")]
        static extern nint CreateIconIndirect(ref ICONINFO icon);

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(nint hObject);

        public Cursor CreateCursorFromBitmap(Bitmap bmp, int xHotspot, int yHotspot)
        {
            var icon = new ICONINFO();
            icon.fIcon = false;
            icon.xHotspot = xHotspot;
            icon.yHotspot = yHotspot;
            icon.hbmColor = bmp.GetHbitmap(Color.FromArgb(0, 0, 0, 0)); // Preserve alpha
            icon.hbmMask = bmp.GetHbitmap(); // Not ideal, but gets around some bugs

            nint ptr = CreateIconIndirect(ref icon);
            return new Cursor(ptr);
        }

    }
}
