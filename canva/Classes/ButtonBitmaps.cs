using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    internal class ButtonBitmaps
    {

        public static ButtonBitmaps Instance { get { return _instance; } }

        public Bitmap Enabled1 { get { if (_enabled1 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled1; } }
        public Bitmap Enabled2 { get { if (_enabled2 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled2; } }
        public Bitmap Enabled3 { get { if (_enabled3 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled3; } }
        public Bitmap Enabled4 { get { if (_enabled4 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled4; } }
        public Bitmap Enabled5 { get { if (_enabled5 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled5; } }
        public Bitmap Enabled6 { get { if (_enabled6 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled6; } }
        public Bitmap Enabled7 { get { if (_enabled7 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled7; } }
        public Bitmap Enabled8 { get { if (_enabled8 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled8; } }
        public Bitmap Disabled1 { get { if (_disabled1 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled1; } }
        public Bitmap Disabled2 { get { if (_disabled2 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled2; } }
        public Bitmap Disabled3 { get { if (_disabled3 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled3; } }
        public Bitmap Disabled4 { get { if (_disabled4 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled4; } }
        public Bitmap Disabled5 { get { if (_disabled5 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled5; } }
        public Bitmap Disabled6 { get { if (_disabled6 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled6; } }
        public Bitmap Disabled7 { get { if (_disabled7 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled7; } }
        public Bitmap Disabled8 { get { if (_disabled8 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled8; } }


        //public static ButtonBitmaps Instance { get { return _instance; } }

        public ButtonBitmaps()
        {

            try
            {
                _enabled1 = GetBitmapFromResource("canva.ico.ico1.ico");
                _enabled2 = GetBitmapFromResource("canva.ico.ico2.ico");
                _enabled3 = GetBitmapFromResource("canva.ico.ico3.ico");
                _enabled4 = GetBitmapFromResource("canva.ico.ico4.ico");
                _enabled5 = GetBitmapFromResource("canva.ico.ico5.ico");
                _enabled6 = GetBitmapFromResource("canva.ico.ico6.ico");
                _enabled7 = GetBitmapFromResource("canva.ico.ico7.ico");
                _enabled8 = GetBitmapFromResource("canva.ico.ico8.ico");


                _disabled1 = GetBitmapFromResource("canva.ico.ic01.ico");
                _disabled2 = GetBitmapFromResource("canva.ico.ic02.ico");
                _disabled3 = GetBitmapFromResource("canva.ico.ic03.ico");
                _disabled4 = GetBitmapFromResource("canva.ico.ic04.ico");
                _disabled5 = GetBitmapFromResource("canva.ico.ic05.ico");
                _disabled6 = GetBitmapFromResource("canva.ico.ic06.ico");
                _disabled7 = GetBitmapFromResource("canva.ico.ic07.ico");
                _disabled8 = GetBitmapFromResource("canva.ico.ic08.ico");
            }
            catch { }


        }


        private Bitmap? GetBitmapFromResource(String resource)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream s = asm.GetManifestResourceStream(resource))
            {
                Icon ico = new Icon(s);
                return ico.ToBitmap();
            }

        }



        private Bitmap? _disabled1;
        private Bitmap? _disabled2;
        private Bitmap? _disabled3;
        private Bitmap? _disabled4;
        private Bitmap? _disabled5;
        private Bitmap? _disabled6;
        private Bitmap? _disabled7;
        private Bitmap? _disabled8;

        private Bitmap? _enabled1;
        private Bitmap? _enabled2;
        private Bitmap? _enabled3;
        private Bitmap? _enabled4;
        private Bitmap? _enabled5;
        private Bitmap? _enabled6;
        private Bitmap? _enabled7;
        private Bitmap? _enabled8;



        private static ButtonBitmaps _instance = new ButtonBitmaps();

        //private static ButtonBitmaps _instance = new ButtonBitmaps();

    }
}
