using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUtil
{
    internal static  class ImageSaver
    {

        public static void SaveImage(byte[] imageBytes, String imgFileName, out String fullFilePath)
        {
            string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appName = $"{Process.GetCurrentProcess().ProcessName.Replace(" ", "_")}";

            String fileName = $"{imgFileName}.png";


            String fullPath = Path.Combine(appDataLocalPath, appName, fileName);
            fullFilePath = fullPath;

            File.WriteAllBytes(fullPath, imageBytes);
        }

    }
}
