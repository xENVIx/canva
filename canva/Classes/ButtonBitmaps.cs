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
        public Bitmap Disabled1 { get { if (_disabled1 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled1; } }
        public Bitmap Disabled2 { get { if (_disabled2 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled2; } }
        public Bitmap Disabled3 { get { if (_disabled3 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled3; } }
        public Bitmap Disabled4 { get { if (_disabled4 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled4; } }


        //public static ButtonBitmaps Instance { get { return _instance; } }

        public ButtonBitmaps()
        {

            try
            {
                _enabled1 = GetBitmapFromResource("canva.ico.ico1.ico");
                _enabled2 = GetBitmapFromResource("canva.ico.ico2.ico");
                _enabled3 = GetBitmapFromResource("canva.ico.ico3.ico");
                _enabled4 = GetBitmapFromResource("canva.ico.ico4.ico");


                _disabled1 = GetBitmapFromResource("canva.ico.ic01.ico");
                _disabled2 = GetBitmapFromResource("canva.ico.ic02.ico");
                _disabled3 = GetBitmapFromResource("canva.ico.ic03.ico");
                _disabled4 = GetBitmapFromResource("canva.ico.ic04.ico");
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

        private Bitmap? _enabled1;
        private Bitmap? _enabled2;
        private Bitmap? _enabled3;
        private Bitmap? _enabled4;



        private static ButtonBitmaps _instance = new ButtonBitmaps();

        //private static ButtonBitmaps _instance = new ButtonBitmaps();

    }
}
