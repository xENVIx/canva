using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI.Special
{
    public class ComboBoxWithLabel : MyComboBox
    {

        public MyLabel LabelProperties { get {  return _tbLabel; } set { _tbLabel = value; } }

        public string LabelText { get { return _tbLabel.Text; } set { _tbLabel.Text = value; } }


        public ComboBoxWithLabel() : base()
        {

            _tbLabel.Size = new Size(this.Width, 15);


        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent != null)
            {
                this.Parent.Controls.Add(_tbLabel);
                PositionLabel();
            }
        }

        private void PositionLabel()
        {
            if (_tbLabel.Parent == this.Parent)
            {
                _tbLabel.Location = new Point(this.Location.X, this.Location.Y - (_tbLabel.Height));
            }
        }

        private MyLabel _tbLabel = new MyLabel();

    }
}
