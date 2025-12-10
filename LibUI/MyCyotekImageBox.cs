using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI
{
    public class MyCyotekImageBox : Cyotek.Windows.Forms.ImageBox
    {


        public bool SupressPan
        {
            get
            {
                return _suppressPan;
            }
            set
            {
                _suppressPan = value;
            }
        }



        public MyCyotekImageBox() : base()
        {

        }


        protected override void OnMouseDown(MouseEventArgs e)
        {

            if (_suppressPan && e.Button == MouseButtons.Left)
                return;


            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {


            if (_suppressPan && e.Button == MouseButtons.Left)
                return;

            base.OnMouseMove(e);
        }


        private bool _suppressPan = false;

    }
}
