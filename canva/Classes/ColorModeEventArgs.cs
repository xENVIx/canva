using canva.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    public class ColorModeEventArgs : EventArgs
    {

        public EColorMode? ColorMode { get { return _colorMode; } set { _colorMode = value; } }

        public ColorModeEventArgs(EColorMode? colorMode = null) : base()
        {

            _colorMode = colorMode;

        }


        private EColorMode? _colorMode;



    }
}
