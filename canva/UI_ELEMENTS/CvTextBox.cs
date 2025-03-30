using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.UI_ELEMENTS
{
    public class CvTextBox : TextBox
    {

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor { get { return base.BackColor; } set { } }
        public override Color ForeColor { get { return base.ForeColor; } set { } }
        public BorderStyle BorderStyle { get { return base.BorderStyle; } set { } }

        public CvTextBox() : base()
        {

            base.BackColor = DAT.Config.Instance.ForegroundColor;

            base.ForeColor = DAT.Config.Instance.TextColor;

            base.BorderStyle = BorderStyle.FixedSingle;
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            base.BorderStyle = BorderStyle.FixedSingle; // Reassert control
        }
    }
}
