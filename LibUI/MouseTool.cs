using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using System.Drawing;

namespace LibUtil
{
    public class MouseTool : IMessageFilter
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        public struct POINT
        {
            public int X;
            public int Y;
        }

        public Point GetGlobalCursorPosition()
        {
            GetCursorPos(out POINT p);
            return new Point(p.X, p.Y);
        }


        private const int WM_LBUTTONDOWN = 0x0201;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                Console.WriteLine("Mouse click detected within app window");
            }
            return false;
        }

        public MouseTool()
        {
            
        }

    }
}
