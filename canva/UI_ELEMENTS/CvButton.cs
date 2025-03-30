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
        public override Color ForeColor { get { return base.ForeColor; } set { } }

        public FlatStyle FlatStyle { get { return base.FlatStyle; } set { } }

        public FlatButtonAppearance FlatAppearance { get { return base.FlatAppearance; } set { } }


        public CvButton() : base()
        {

            base.BackColor = DAT.Config.Instance.ForegroundColor;

            base.ForeColor = DAT.Config.Instance.TextColor;

            base.FlatStyle = FlatStyle.Flat;



        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            base.FlatStyle = FlatStyle.Flat; // Reassert control

            base.FlatAppearance.MouseDownBackColor = Color.HotPink;
            base.FlatAppearance.MouseOverBackColor = Color.Cyan;
            base.FlatAppearance.BorderColor = DAT.Config.Instance.ForegroundColor;
        }


        public void SetButton(bool enabled, Image? backgroundImage = null, bool visible = true)
        {
            this.Enabled = enabled;
            
            if (backgroundImage != null) this.BackgroundImage = backgroundImage;
            
            this.Visible = visible;
        }


    }
}
