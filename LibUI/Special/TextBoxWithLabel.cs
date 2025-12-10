using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI.Special
{
    public class TextBoxWithLabel : MyTextBox
    {

        #region PUBLIC

        #region VARIABLES

        public MyLabel LabelProperties { get {  return _tbLabel; } set { _tbLabel = value; } }

        public string LabelText { get { return _tbLabel.Text; } set { _tbLabel.Text = value; } }

        #endregion

        #region CONSTRUCTORS

        public TextBoxWithLabel() : base()
        {

            _tbLabel.Size = new Size(this.Width, 15);


        }

        #endregion

        #endregion

        #region PROTECTED

        #region METHODS

        #region OVERRIDE

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent != null)
            {
                this.Parent.Controls.Add(_tbLabel);
                PositionLabel();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {



        }


        #endregion

        #endregion

        #endregion

        #region PRIVATE

        #region METHODS

        private void PositionLabel()
        {
            if (_tbLabel.Parent == this.Parent)
            {
                _tbLabel.Location = new Point(this.Location.X, this.Location.Y - (_tbLabel.Height));
            }
        }

        #endregion

        #region VARIABLES

        private MyLabel _tbLabel = new MyLabel();

        #endregion

        #endregion
    }
}
