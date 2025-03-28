using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using LibUtil;

using LibUI;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        [DataMember] public bool ShowWarnings { get { return _showWarnings; } set { _showWarnings = value; } }

        #endregion

        public Color BackgroundColor
        {
            get
            {
                try
                {
                    if (IsValidHexColor(_appColor))
                    {
                        return HexToColor(_appColor);
                    }
                    else return HexToColor("#DCFFFF");
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }

        public Color ForegroundColor
        {
            get
            {
                try
                {
                    if (IsValidHexColor(_appColor))
                    {
                        return HexToColor(_appColor);
                    }
                    else return HexToColor("#DCFFFF", true);
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

        }

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


        // 220, 255, 255
        private String _appColor = "#DCFFFF";

        private String _appTitle = "♥ C A N V A ♥";


        private bool _showWarnings = true;

        #endregion

        #region METHODS

        #region STATIC

        private static bool IsValidHexColor(String value)
        {
            return Regex.IsMatch(value, @"^#?[0-9A-Fa-f]{6}$");
        }

        private static Color HexToColor(String hex, bool foreground = false)
        {
            // Strip '#' if present
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);

            if (foreground)
            {
                if (r < 255) r -= 15;
                if (g < 255) g -= 15;
                if (b < 255) b -= 15;
            }

            return Color.FromArgb(r, g, b);
        }

        #endregion

        #endregion

        #endregion



    }
}
