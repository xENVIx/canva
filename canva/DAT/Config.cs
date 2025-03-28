using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using LibUtil;

using LibUI;
using System.Diagnostics;

namespace canva.DAT
{

    [DataContract]
    public class Config
    {

        #region PUBLIC

        #region VARIABLES

        #region STATIC

        public static Config Instance { get { return _instance; } }

        #endregion

        #region DATA-MEMBERS
        [DataMember] public ENUM.EAppOrientation AppOrientation { get { return _appOrientation; } set { _appOrientation = value; } }
        [DataMember] public String AppBackgroundColor { get { return _appColor; } set { _appColor = value; } }
        [DataMember] public String AppTitle { get { return _appTitle; } set { _appTitle = value; } }

        #endregion

        #endregion

        #region METHODS

        #region STATIC

        public static void OnInit()
        {



            try
            {
                string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appName = $"{Process.GetCurrentProcess().ProcessName.Replace(" ", "_")}";

                String appDataPath = Path.Combine(appDataLocalPath, appName);

                XML.SetFilePath = appDataPath;

                object data;
                if (XML.DeserializeXML(out data, typeof(Config)))
                {
                    _instance = (Config)data;
                }
                else
                {

                    try
                    {
                        XML.SerializeXML(typeof(Config), _instance);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    if (MyMessageBox.ShowAskQuestion("This application uses a config file for various app settings, stored in your users \'%appdata\' directory.\n" +
                        "Would you like me to take you there now?", "Go to appdata directory?") == DialogResult.Yes)
                    {

                        if (!DirectoryUtl.OpenDirectory(appDataPath))
                        {
                            MyMessageBox.ShowWarning($"Failed to open directory: \'{appDataPath}\'");
                            return;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError($"Fatal error generating config file, using default configuration...\n" +
                            $"Ex: {ex.Message}");
                _instance = new Config();
                return;
            }

        }

        #endregion

        #endregion

        #region CONSTRUCTORS


        public Config()
        {

        }


        #endregion

        #endregion


        #region PRIVATE

        #region VARIABLES

        #region STATIC

        private static Config _instance = new Config();

        #endregion


        private ENUM.EAppOrientation _appOrientation = ENUM.EAppOrientation.HORIZONTAL;

        private String _appColor = "#000000";

        private String _appTitle = "♥ C A N V A ♥";

        #endregion

        #endregion



    }
}
