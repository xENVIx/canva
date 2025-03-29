

using canva.DAT;

using canva.UI_ELEMENTS;
using LibUI;
using System.Diagnostics;

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

                    UserInterface.ToggleAppOrient();
                    UserInterface.PostInit();

                    ToggleAppOrient = false;
                }

                Application.Run(UserInterface.Instance);

            } while (ToggleAppOrient);

        }




        public static String appDataFolder = "";
        public static bool Debug = false;

        public static bool ToggleAppOrient = false;





    }
}