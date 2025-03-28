

using canva.DAT;

using canva.UI_ELEMENTS;
using LibUI;

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
                Config.OnInit();

                UserInterface.OnInit();


            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError($"Fatal Error During App Initialization: {ex.Message}");
                return;
            }



            Application.Run(UserInterface.Instance);

        }





        public static bool Debug = false;







    }
}