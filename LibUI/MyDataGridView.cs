using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI
{
    public class MyDataGridView : System.Windows.Forms.DataGridView
    {


        public MyDataGridView() : base()
        {
            CellClick += _cell_Click;
        }

        protected virtual void _cell_Click(object? sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0)
            {
                _selRow = -1;
                return;
            }

            if (e.RowIndex >= this.Columns.Count)
            {
                _selRow = -1;
                return;
            }

            if (this.Rows[e.RowIndex].Cells[0] == null)
            {
                _selRow = -1;
                return;
            }



            _selRow = e.RowIndex;



        }

        protected int _selRow = -1;


    }
}
