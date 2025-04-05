using canva.Classes;
using LibUI;
using LibUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace canva.DAT
{

    [DataContract] public class AppDat
    {

        #region PUBLIC

        #region VARIABLES

        #region STATIC

        public static AppDat Instance { get { return _instance; } }

        #endregion


        #region DATAMEMBERS

        [DataMember] public CvColor[] ColorData { get { return _colors; } set { _colors = value; } }

        #endregion

        public Color[] Colors 
        { 
            get 
            {
                Color[] retColors = new Color[_colors.Length];
                for (int i = 0; i < _colors.Length; i++)
                {
                    retColors[i] = _colors[i].Color;
                }

                return retColors;
            } 
        }


        public Color Color1 
        { 
            get 
            { 
                return _colors[0].Color; 
            } 
            set 
            {  

                _colors[0].Color = value;
            } 
        }
        public Color Color2 
        { 
            get 
            { 
                return _colors[1].Color; 
            } 
            set 
            { 
                _colors[1].Color = value;
            } 
        }
        public Color Color3
        {
            get
            {
                return _colors[2].Color;
            }
            set
            {
                _colors[2].Color = value;
            }
        }

        public Color Color4
        {
            get
            {
                return _colors[3].Color;
            }
            set
            {
                _colors[3].Color = value;
            }
        }
        public Color Color5
        {
            get
            {
                return _colors[4].Color;
            }
            set
            {
                _colors[4].Color = value;
            }
        }
        public Color Color6
        {
            get
            {
                return _colors[5].Color;
            }
            set
            {
                _colors[5].Color = value;
            }
        }
        public Color Color7
        {
            get
            {
                return _colors[6].Color;
            }
            set
            {
                _colors[6].Color = value;
            }
        }
        public Color Color8
        {
            get
            {
                return _colors[7].Color;
            }
            set
            {
                _colors[7].Color = value;
            }
        }

        #endregion

        #region METHODS

        #region STATIC

        public static void OnInit()
        {


            CvColor.OnInit();

            try
            {

                object data;


                if (XML.DeserializeXML(out data, typeof(AppDat)))
                {
                    _instance = (AppDat)data;

                }
                else
                { 
                    for (int i = 0; i < _instance._colors.Length; i++)
                    {
                        _instance._colors[i] = new CvColor();
                    }

                    try
                    {
                        XML.SerializeXML(typeof(AppDat), _instance);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    

                }
            }
            catch (Exception ex)
            {
                throw;
            }


            CvColor._postInit = true;

        }

        #endregion


        public void SaveData()
        {

            try
            {
                LibUtil.XML.SerializeAppDataXML(typeof(AppDat), this);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError(ex);
            }
        }


        /// <summary>
        /// input color 1, 2, 3, 4 where 1 correlates to index position 0
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool ColorSet(int color)
        {


            return _colors[color - 1].ColorSet;


        }

        #endregion

        #region CONSTRUCTORS

        public AppDat()
        {
            for (int i = 0; i < _colors.Length; i++)
            {
                _colors[i] = new Classes.CvColor();
            }
        }

        #endregion

        #endregion


        #region PRIVATE

        #region VARIABLES

        #region STATIC

        private static AppDat _instance = new AppDat();

        #endregion

        private Classes.CvColor[] _colors = new Classes.CvColor[8];
        //private bool[] _colorSet = new bool[8];



        #endregion

        #endregion


    }
}
