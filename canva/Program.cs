

using canva.DAT;

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

            //LOG.Logger.OnInit("");
            Config.OnInit();

            Application.Run(UCCanva.Instance);
        }





        public static bool Debug = false;






    }
}