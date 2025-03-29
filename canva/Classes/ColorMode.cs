using canva.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    public class ColorMode
    {

        public static ColorMode Instance { get { return _instance; } }


        public EColorMode GetColorMode { get { return _colorMode; } }
        public EColorMode SetColorMode
        {
            set
            {
                
                if (_colorMode != value)
                {
                    _colorMode = value;
                    ColorModeChanged?.Invoke(this, new ColorModeEventArgs(value));
                }

            }
        }


        public void SetColorModeNone()
        {
            SetColorMode = EColorMode.NONE;
        }


        public event EventHandler<ColorModeEventArgs>? ColorModeChanged;

        public EColorMode Set
        {
            set
            {
                //if (_colorMode == EColorMode.NO_IMG && value != EColorMode.NONE) return;

                if (_colorMode != value)
                {
                    ColorModeChanged?.Invoke(this, new ColorModeEventArgs(value));
                    _colorMode = value;

                }
            }
        }

        public EColorMode Get
        {
            get { return _colorMode; }
        }

        public ColorMode()
        {

        }

        private EColorMode _colorMode = EColorMode.NO_IMG;



        private static ColorMode _instance = new ColorMode();

    }
}
