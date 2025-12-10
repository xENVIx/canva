using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OFD = System.Windows.Forms.OpenFileDialog;


namespace LibUI
{
    public class FileTools : LibUtil.FileTools
    {

        /// <summary>
        /// filter example: "CSV Files (*.csv)|*.csv|All Files(*.*)|*.*"
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool OpenFileDialogReturnFilePath(String filter, out String fileName, String path = "")
        {
            bool ret = false;
            fileName = "";

            try
            {
                using OFD ofd = new OFD
                {
                    InitialDirectory = path,
                    Filter = filter,
                    Multiselect = false,
                    Title = "Select A File"
                };


                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = false;
            }


            return ret;
        }

        public bool OpenFileDialogReturnFile(out String fileName, String path = "")
        {
            bool ret = false;
            fileName = "";

            try
            {
                using OFD ofd = new OFD
                {
                    InitialDirectory = path,
                    Filter = "CSV Files (*.csv)|*.csv|All Files(*.*)|*.*",
                    Multiselect = false,
                    Title = "Select an IBA Exported CSV File"
                };


                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = false;
            }


            return ret;
        }


        public static FileTools Instance { get { if (_instance == null) throw new ArgumentNullException(nameof(_instance)); return (FileTools)_instance; } set { _instance = value; } }
    }
}
