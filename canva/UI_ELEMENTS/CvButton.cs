using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.UI_ELEMENTS
{
    public class CvButton : Button
    {

        public CvButton() : base()
        {

            this.BackColor = DAT.Config.Instance.BackgroundColor;

        }


        public void SetButton(bool enabled, Image? backgroundImage = null, bool visible = true)
        {
            this.Enabled = enabled;
            
            if (backgroundImage != null) this.BackgroundImage = backgroundImage;
            
            this.Visible = visible;
        }


    }
}
