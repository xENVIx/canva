using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

namespace LibUtil
{
    public class DirectoryTools
    {

        #region PUBLIC

        #region VARIABLES

        #region STATIC

        public static DirectoryTools Instance { get { if (_instance == null) throw new ArgumentNullException("FileTools Instance Is Null"); return _instance; } }

        #endregion

        #endregion

        #region METHODS

        public bool CheckCreateDirectory(String dirPath)
        {

            if (Directory.Exists(dirPath)) return true;
            else
            {
                try
                {
                    Directory.CreateDirectory(dirPath);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }


        }



        #endregion

        #endregion

        #region PRIVATE

        #region CONSTRUCTORS

        private DirectoryTools()
        {

        }

        #endregion

        #region VARIABLES

        #region STATIC

        private static DirectoryTools _instance = new DirectoryTools();

        #endregion

        #endregion

        #endregion

    }
}
