using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    public class OpenMenuEventArgs : EventArgs
    {

        public Point MouseLocation { get; set; }

        public OpenMenuEventArgs(Point loc)
        {
            MouseLocation = loc;
        }


    }
}
