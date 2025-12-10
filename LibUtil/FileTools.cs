using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;


namespace LibUtil
{
    public class FileTools
    {

        #region CONSTRUCTORS

        #region PUBLIC

        public FileTools()
        {

        }

        #endregion // public

        #endregion

        #region GET-SET

        #region PUBLIC

        #region STATIC

        //public static FileTools Instance { get { if (_instance == null) throw new ArgumentNullException("FileTools Instance Is Null"); return _instance; } }

        #endregion

        #endregion

        #endregion

        #region METHODS

        /// <summary>
        /// Returns the file in bytes based on given full file name (e.g. file path), throws exception if file not found
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public byte[] GetFileBytes(String fileName)
        {

            try
            {
                // first check that file exists
                if (!File.Exists(fileName)) throw new FileNotFoundException($"File \'{fileName}\' Not Found");

                return File.ReadAllBytes(fileName);
            }
            catch (FileNotFoundException fEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Returns a list of binary datasets based on particular filetype passed into argument.  Filetype ex. *.bin
        /// Will throw an error if directory does not exist, or if filetype not found in directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public List<byte[]> GetFolderBytes(String directory, String fileType)
        {
            try
            {
                if (!Directory.Exists(directory)) throw new DirectoryNotFoundException($"Directory \'{directory}\' Does Not Exist");

                DirectoryInfo di = new DirectoryInfo(directory);

                FileInfo[] fi = di.GetFiles(fileType);

                if (fi.Length == 0) throw new FileNotFoundException($"No Files With Extension \'{fileType}\' Found In Directory \'{directory}\'");

                List<Byte[]> dataSet = new List<byte[]>();

                foreach (FileInfo file in fi)
                {
                    byte[] data = GetFileBytes(file.FullName);
                    dataSet.Add(data);
                }

                return dataSet;
            }
            catch (FileNotFoundException fEx)
            {
                throw;
            }
            catch (DirectoryNotFoundException dirEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }





        public bool DeleteFile(String filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }


        public String RandomFileName
        {
            get
            {
                const int length = 16;
                const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                char[] fileName = new char[length];
                using (var rng = RandomNumberGenerator.Create())
                {
                    byte[] randomBytes = new byte[length];
                    rng.GetBytes(randomBytes);

                    for (int i = 0; i < fileName.Length; i++)
                    {
                        fileName[i] = chars[randomBytes[i] % chars.Length];
                    }
                }

                return new string(fileName);
            }
        }

        #endregion

        #region VARIABLES

        #region PROTECTED

        #region STATIC

        protected static FileTools _instance = new FileTools();

        #endregion

        #endregion

        #endregion

    }
}
