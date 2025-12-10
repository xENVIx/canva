using LibUI.Special;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibUI
{
    public partial class MyForm : Form
    {

        public MyForm()
        {

        }

        public MyForm(bool hasCmdBar = false, DockStyle ? dockStyle = null, CmdBar.E_BUTTONS? selButtons = null)
        {
            InitializeComponent();


            if (hasCmdBar)
            {
                DockStyle dock;
                if (dockStyle != null) dock = (DockStyle)dockStyle;
                else dock = DockStyle.Bottom;

                CmdBar.E_BUTTONS _selBut;
                if (selButtons != null) _selBut = (CmdBar.E_BUTTONS)selButtons;
                else _selBut = CmdBar.E_BUTTONS.OK_CANCEL;

                _cmdBar = new CmdBar(_selBut);


                this.Controls.Add(_cmdBar);
                this._cmdBar.Dock = dock;


                switch (_selBut)
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



        private CmdBar _cmdBar = new CmdBar();
    }
}
