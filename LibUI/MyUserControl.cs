using LibUI.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI
{
    public class MyUserControl : UserControl
    {

        #region PUBLIC

        #region VARIABLES



        #endregion

        #region CONSTRUCTORS

        public MyUserControl()
        {

        }

        public MyUserControl(DockStyle? dockStyle = null, bool hasCmdBar = false, CmdBar.E_BUTTONS? btnSel = null) : base()
        {


            if (hasCmdBar)
            {

                DockStyle dock;
                CmdBar.E_BUTTONS btn;
                if (dockStyle == null) dock = DockStyle.Bottom;
                else dock = (DockStyle)dockStyle;

                if (btnSel == null) btn = CmdBar.E_BUTTONS.ADD_REMOVE;
                else btn = (CmdBar.E_BUTTONS)btnSel;


                _cmdBar = new CmdBar(btn);

                this.Controls.Add(_cmdBar);
                _cmdBar.Dock = dock;
                this._cmdBar.Visible = true;


                switch (btn)
                {
                    case CmdBar.E_BUTTONS.ADD_REMOVE:
                        _cmdBar.AddClick += _cmdBar_AddClick;
                        _cmdBar.RemoveClick += _cmdBar_RemoveClick;
                        break;
                    case CmdBar.E_BUTTONS.OK_CANCEL:
                        _cmdBar.OkClick += _cmdBar_OkClick;
                        _cmdBar.CancelClick += _cmdBar_CancelClick;
                        break;
                }
            }


           

        }


        #endregion

        #endregion

        #region PROTECTED

        #region METHODS

        #region VIRTUAL

        protected virtual void _cmdBar_RemoveClick(object sender, EventArgs e)
        {

        }

        protected virtual void _cmdBar_AddClick(object sender, EventArgs e)
        {

        }

        protected virtual void _cmdBar_CancelClick(object sender, EventArgs e)
        {

        }

        protected virtual void _cmdBar_OkClick(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region VARIABLES

        protected CmdBar CommandBar { get { _cmdBar ??= new CmdBar(); return _cmdBar; } }

        #endregion

        #endregion


        #region PRIVATE

        #region VARIABLES

        private CmdBar _cmdBar = new CmdBar();

        #endregion

        #endregion

    }
}
