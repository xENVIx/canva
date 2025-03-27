using LOG = Logger;

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

            Application.Run(UserInterface.Instance);
        }


        public static LOG.Logger Log
        {
            get
            {
                if (LOG.Logger.LogBooks.ContainsKey(LOG.ENUM.ELogBook.MAIN)) return LOG.Logger.LogBooks[LOG.ENUM.ELogBook.MAIN];

                throw new KeyNotFoundException($"Main Logbook Not Found");
            }
        }



        public static bool Debug = false;






    }
}