using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.UI_ELEMENTS
{
    public class CvButton : Button
    {

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor { get { return base.BackColor; }  set {  } }


        public CvButton() : base()
        {

            base.BackColor = DAT.Config.Instance.ForegroundColor;

        }


        public void SetButton(bool enabled, Image? backgroundImage = null, bool visible = true)
        {
            this.Enabled = enabled;
            
            if (backgroundImage != null) this.BackgroundImage = backgroundImage;
            
            this.Visible = visible;
        }


    }
}
