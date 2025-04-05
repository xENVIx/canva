using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CLR = System.Drawing.Color;
using BOOL = bool;

namespace canva.Classes
{
    [DataContract]
    public class CvColor
    {

        #region PUBLIC

        #region VARIABLES

        #region STATIC

        /// <summary>
        /// must be set to true after init for color change timer to work properly
        /// </summary>
        public static BOOL _postInit = false;

        #endregion

        [DataMember] public String ColorHex { get { return ColorHexString(_color); } set { _color = HexStringColor(value); } }
        [DataMember] public BOOL ColorSet { get { return _colorSet; } set { _colorSet = value; } }  

        public CLR Color 
        { 
            get 
            { 
                return _color; 
            } 
            set 
            { 
                if (_postInit && (ColorHex != ColorHexString(value)))
                {
                    _colorSetTimer.Start();
                }

                _color = value;
                _colorSet = true;


            } 
        }

        #endregion

        #region METHODS

        #region STATIC

        public static void OnInit()
        {
            _colorSetTimer.Elapsed += _colorSetTimer_Elapsed;
            _colorSetTimer.Interval = 1000;
            _colorSetTimer.AutoReset = false;

        }

        private static void _colorSetTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // save data
            DAT.AppDat.Instance.SaveData();
        }

        #endregion

        #endregion

        #region CONSTRUCTORS

        public CvColor()
        {

        }

        #endregion

        #endregion


        #region PRIVATE

        #region METHODS

        #region STATIC

        private static String ColorHexString(CLR color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            
        }

        private static CLR HexStringColor(String hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6)
                throw new ArgumentException("Hex color must be 6 digits long.");

            int r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(r, g, b);
        }

        #endregion

        #endregion

        #region VARIABLES

        #region STATIC


        private static CvTimer _colorSetTimer = new CvTimer();

        #endregion

        private CLR _color = CLR.White;
        private BOOL _colorSet = false; 

        #endregion

        #endregion

    }
}
