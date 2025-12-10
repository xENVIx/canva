using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI.Special
{
    public class ColorBox : System.Windows.Forms.Panel
    {



        #region PUBLIC

        #region CONSTRUCTORS

        public ColorBox()
        {
            this.BackColor = Color.White;
        }

        #endregion

        #region ENUMS

        public enum EColor
        {
            RED,
            ORANGE,
            YELLOW,
            GREEN,
            BLUE,
            VIOLET,
        }

        #endregion

        #region VARIABLES

        public Color SetBackColor { get { return this.BackColor; } set { this.BackColor = value; } }

        #endregion

        #endregion


    }
}
