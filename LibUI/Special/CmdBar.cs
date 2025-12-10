using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI.Special
{
    public class CmdBar : MyPanel
    {

        #region PUBLIC

        #region ENUM

        public enum E_BUTTONS
        {
            ADD_REMOVE,
            OK,
            OK_CANCEL,
            CONFIRM_REJECT,
        }

        #endregion

        #region DELEGATES

        public delegate void ButtonClick(object sender, EventArgs e);

        #endregion

        #region EVENTS

        public event ButtonClick AddClick;
        public event ButtonClick RemoveClick;
        public event ButtonClick OkClick;
        public event ButtonClick CancelClick;

        #endregion

        #region VARIABLES

        public MyButton AddButton { get { return _btnAdd; } }
        public MyButton RemoveButton { get { return _btnRemove; } }

        public String SetAddButtonText { set { _btnAdd.Text = value; } }
        public String SetRemoveButtonText { set { _btnRemove.Text = value; } }

        #endregion

        #region METHODS

        public void DoResize()
        {
            _btnAdd.Location = new Point(10, 10);
            _btnRemove.Location = new Point(_btnAdd.Location.X + _btnAdd.Width + 10, _btnAdd.Location.Y);

            _btnOk.Location = new Point(10, 10);
            _btnCancel.Location = new Point(_btnOk.Location.X + _btnOk.Width + 10, _btnOk.Location.Y);
        }

        #endregion

        #region CONSTRUCTORS

        public CmdBar()
        {

        }

        public CmdBar(E_BUTTONS btnSel) : base()
        {


            Controls.Add(_btnAdd);
            Controls.Add(_btnRemove);
            Controls.Add(_btnOk);
            Controls.Add(_btnCancel);

            
            Resize += CmdBar_Resize;
            _btnAdd.Click += _btnAdd_Click;
            _btnRemove.Click += _btnRemove_Click;
            _btnOk.Click += _btnOk_Click;
            _btnCancel.Click += _btnCancel_Click;


            SetupButtons(btnSel);


            _btnAdd.Text = "Add";
            _btnAdd.Size = new Size(100, 25);

            _btnRemove.Text = "Remove";
            _btnRemove.Size = new Size(100, 25);

            _btnOk.Text = "OK";
            _btnOk.Size = new Size(100, 25);

            _btnCancel.Text = "Cancel";
            _btnCancel.Size = new Size(100, 25);

            DoResize();



            this.BorderStyle = BorderStyle.Fixed3D;
            this.Height = 50;


        }

        private void _btnCancel_Click(object? sender, EventArgs e)
        {

            CancelClick?.Invoke(this, e);

        }

        private void _btnOk_Click(object? sender, EventArgs e)
        {
            OkClick?.Invoke(this, e);
        }




        #endregion

        #endregion

        #region PROTECTED

        #region METHODS

        #region EVENTS




        protected void _btnRemove_Click(object? sender, EventArgs e)
        {
            if (_btnSel == E_BUTTONS.ADD_REMOVE)
                RemoveClick?.Invoke(this, e);
        }

        protected void _btnAdd_Click(object? sender, EventArgs e)
        {
            if (_btnSel == E_BUTTONS.ADD_REMOVE)
                AddClick?.Invoke(this, e);

        }

        #endregion

        #endregion

        #endregion

        #region PRIVATE

        #region METHODS

        #region EVENTS

        private void CmdBar_Resize(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DoResize();
        }

        #endregion

        private void SetupButtons(E_BUTTONS btnSel)
        {
            _btnSel = btnSel;

            HideAllButtons();
            switch (_btnSel)
            {
                case E_BUTTONS.ADD_REMOVE: SetupAddRemove(); break;
                case E_BUTTONS.OK_CANCEL: SetupOkCancel(); break;
                default: throw new NotImplementedException($"Not Implemented: {_btnSel}");
            }
        }

        private void HideAllButtons()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(MyButton))
                {
                    ctrl.Hide();
                }

            }

        }

        private void SetupAddRemove()
        {
            this._btnAdd.Visible = true;
            this._btnRemove.Visible = true;
            
        }

        private void SetupOkCancel()
        {
            this._btnOk.Visible = true;
            this._btnCancel.Visible = true;
        }
        #endregion

        #region VARIABLES

        private MyButton _btnAdd = new MyButton();
        private MyButton _btnRemove = new MyButton();
        private MyButton _btnOk = new MyButton();
        private MyButton _btnCancel = new MyButton();
        private E_BUTTONS _btnSel;

        #endregion

        #endregion

    }
}
