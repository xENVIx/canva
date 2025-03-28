using canva.DAT;
using canva.ENUM;
using LibUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canva.UI_ELEMENTS
{
    public partial class UserInterface : Form
    {


        #region PUBLIC

        #region VARIABLES

        #region STATIC

        public static UserInterface Instance { get { if (_instance == null) throw new ArgumentNullException("Main UI Not Yet Initialized!!!"); return _instance; } }

        #endregion

        public bool ImageLoaded
        {
            set
            {
                if (value)
                {
                    Classes.ColorMode.Instance.Set = EColorMode.NONE;
                }
                else
                    Classes.ColorMode.Instance.Set = EColorMode.NO_IMG;
            }
        }

        #endregion

        #region METHODS

        #region STATIC

        public static void OnInit()
        {
            EAppOrientation appOrient = new EAppOrientation();

            if (Config.Instance == null)
                appOrient = EAppOrientation.HORIZONTAL;
            else appOrient = Config.Instance.AppOrientation;


            switch (appOrient)
            {
                case EAppOrientation.HORIZONTAL: _instance = new UserInterfaceHoriz(); break;
                case EAppOrientation.VERTICAL: _instance = new UserInterfaceVert(); break;
                default: _instance = new UserInterfaceHoriz(); break;
            }

        }

        #endregion

        #endregion

        #region CONSTRUCTORS

        public UserInterface()
        {
            InitializeComponent();

            



            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream s = asm.GetManifestResourceStream("canva.ico.duck1.ico"))
            {
                this.Icon = new Icon(s);
            }



            if (Config.Instance == null) this.Text = "♥ C A N V A ♥";
            else this.Text = Config.Instance.AppTitle;


            this.Load += FrmMain_Load;



            this.BackColor = Config.Instance.BackgroundColor;



            this._btnPaste.Click += _btnPaste_Click;
            this._btnClose.Click += _btnClose_Click;
        }

        private void _btnClose_Click(object? sender, EventArgs e)
        {

            if (MyMessageBox.ShowAskQuestion("Do you want to close the app?", "Confirm Application Close") == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
                return;
            }

        }

        private void _btnPaste_Click(object? sender, EventArgs e)
        {

            if (Clipboard.ContainsImage())
            {
                Image? image = Clipboard.GetImage();

                if (image != null)
                {

                    _ucCnva.PasteClipboard(image);

                }
                else
                {
                    if (Config.Instance.ShowWarnings)
                        MyMessageBox.ShowWarning("Clipboard could not be loaded into app :(");
                }
            }
            else
            {
                if (Config.Instance.ShowWarnings)
                    MyMessageBox.ShowWarning("The clipboard does not contain an image");
            }

        }



        #endregion

        #endregion

        #region PROTECTED



        #endregion

        #region PRIVATE

        #region METHODS

        #region EVENTS

        private void FrmMain_Load(object? sender, EventArgs e)
        {

            if (Program.Debug)
                DbgWindow.Instance.Show();

        }


        #endregion

        #endregion

        #region VARIABLES

        #region STATIC

        private static UserInterface _instance;

        #endregion

        #endregion

        #region ENUM

        #endregion

        #endregion









    }

}
