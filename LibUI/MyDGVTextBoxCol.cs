using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI
{
    public class MyDGVTextBoxCol : DataGridViewTextBoxColumn
    {


        public MyDGVTextBoxCol(String name, String caption, int width, bool visible = true) : base()
        {

            this.Name = name;
            this.HeaderText = caption;
            this.Width = width;
            this.Visible = visible;

        }


    }
}
