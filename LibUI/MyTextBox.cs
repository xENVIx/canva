using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUI
{
    public class MyTextBox : System.Windows.Forms.TextBox
    {

        #region PUBLIC

        #region CONSTRUCTORS
        public MyTextBox() : base()
        {

        }

        #endregion

        #region ENUM

        public enum E_TB_TYPE
        {
            TEXT,
            NUMERIC,
            FLOAT,
            CURRENCY
        }

        #endregion

        #region VARIABLES

        #region GET-SET

        public double TextAsDouble
        {
            get
            {
                return Double.Parse(Text);
            }
        }

        #endregion

        public E_TB_TYPE TextBoxType { get { return _tbType; } set { _tbType = value; } }

        #endregion

        #region METHODS

        public bool GetDouble(out Double dbl)
        {
            if (Double.TryParse(Text, out dbl))
            {
                return true;
            }

            return false;
        }

        #endregion

        #endregion


        #region PROTECTED

        #region METHODS

        #region OVERRIDE

        protected override void OnTextChanged(EventArgs e)
        {



        }

        #endregion

        #endregion

        #endregion

        #region PRIVATE

        #region VARIABLES

        private E_TB_TYPE _tbType;


        #endregion

        #endregion
    }
}
