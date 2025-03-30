using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.DAT
{
    internal class AppDat
    {

        public static AppDat Instance { get { return _instance; } }


        public Color[] Colors { get { return _colors; } }


        public Color Color1 
        { 
            get 
            { 
                return _colors[0]; 
            } 
            set 
            {  
                _colors[0] = value;
                _colorSet[0] = true;
            } 
        }
        public Color Color2 
        { 
            get 
            { 
                return _colors[1]; 
            } 
            set 
            { 
                _colors[1] = value;
                _colorSet[1] = true;
            } 
        }
        public Color Color3
        {
            get
            {
                return _colors[2];
            }
            set
            {
                _colors[2] = value;
                _colorSet[2] = true;
            }
        }

        public Color Color4
        {
            get
            {
                return _colors[3];
            }
            set
            {
                _colors[3] = value;
                _colorSet[3] = true;
            }
        }



        /// <summary>
        /// input color 1, 2, 3, 4 where 1 correlates to index position 0
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool ColorSet(int color)
        {


            return _colorSet[color - 1];


        }


        internal AppDat()
        {
            for (int i = 0; i < _colorSet.Length; i++)
            {
                _colorSet[i] = false;
            }
        }

        private Color[] _colors = new Color[4];
        private bool[] _colorSet = new bool[4];

        private static AppDat _instance = new AppDat();


    }
}
