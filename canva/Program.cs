

using canva.Classes;
using canva.DAT;

using canva.UI_ELEMENTS;
using LibUI;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace canva
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            try
            {
                //LOG.Logger.OnInit("");
                string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appName = $"{Process.GetCurrentProcess().ProcessName.Replace(" ", "_")}";

                appDataFolder = Path.Combine(appDataLocalPath, appName);


                Config.OnInit();
                AppDat.OnInit();

                ImageCache.OnInit();

                ImageCache.Instance.FilePath = appDataFolder;

                if (!Config.Instance.CacheImages)
                {
                    // clear cache
                    ImageCache.Instance.ClearCache();
                    
                }

                UserInterface.OnInit();


            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError($"Fatal Error During App Initialization: {ex.Message}");
                return;
            }


            do
            {

                if (ToggleAppOrient)
                {
                    Classes.ColorMode.Instance.Set = ENUM.EColorMode.NO_IMG;
                    UserInterface.ToggleAppOrient();
                    UserInterface.PostInit();



                    //UserInterface.Instance.PostColorSet();

                    SavedImages.Instance.LoadCurrentImage();


                    ToggleAppOrient = false;
                }


                UserInterface.Instance.PostColorSet();
                Application.Run(UserInterface.Instance);

            } while (ToggleAppOrient);

        }




        public static String appDataFolder = "";
        public static bool Debug = false;

        public static bool ToggleAppOrient = false;





    }
}