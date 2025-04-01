using canva.Classes;
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


            if (Config.Instance == null)
                _appOrient = EAppOrientation.HORIZONTAL;
            else _appOrient = Config.Instance.AppOrientation;


            switch (_appOrient)
            {
                case EAppOrientation.HORIZONTAL: _instance = new UserInterfaceHoriz(); break;
                case EAppOrientation.VERTICAL: _instance = new UserInterfaceVert(); break;
                default: _instance = new UserInterfaceHoriz(); break;
            }

        }

        public static void PostInit()
        {

            SavedImages.Instance.DeregisterEvents();

            switch (_appOrient)
            {
                case EAppOrientation.HORIZONTAL: _instance = new UserInterfaceHoriz(); break;
                case EAppOrientation.VERTICAL: _instance = new UserInterfaceVert(); break;
                default: throw new Exception();
            }
        }

        public static void ToggleAppOrient()
        {
            switch (_appOrient)
            {
                case EAppOrientation.HORIZONTAL: _appOrient = EAppOrientation.VERTICAL; break;
                case EAppOrientation.VERTICAL: _appOrient = EAppOrientation.HORIZONTAL; break;

                default: throw new Exception("Could not toggle app orientation");
                    
            }
        }

        #endregion

        public void PostColorSet()
        {
            
            if (AppDat.Instance.ColorSet(1))
            {
                _ucCmd.ColorPicked1(AppDat.Instance.Color1);
            }

            if (AppDat.Instance.ColorSet(2))
            {
                _ucCmd.ColorPicked2(AppDat.Instance.Color2);
            }

            if (AppDat.Instance.ColorSet(3))
            {
                _ucCmd.ColorPicked3(AppDat.Instance.Color3);
            }

            if (AppDat.Instance.ColorSet(4))
            {
                _ucCmd.ColorPicked4(AppDat.Instance.Color4);
            }

            if (AppDat.Instance.ColorSet(5))
            {
                _ucCmd.ColorPicked5(AppDat.Instance.Color5);
            }

            if (AppDat.Instance.ColorSet(6))
            {
                _ucCmd.ColorPicked6(AppDat.Instance.Color6);
            }

            if (AppDat.Instance.ColorSet(7))
            {
                _ucCmd.ColorPicked7(AppDat.Instance.Color7);
            }

            if (AppDat.Instance.ColorSet(8))
            {
                _ucCmd.ColorPicked8(AppDat.Instance.Color8);
            }

        }

        #endregion

        #region CONSTRUCTORS

        public UserInterface()
        {
            InitializeComponent();



            this.KeyPreview = true;

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


            this._ucCnva.ColorPicked += _ucCnva_ColorPicked;

            this._ucCmd.OpenMenu += _ucCmd_OpenMenu;


            


            ToolStripMenuItem op1 = new ToolStripMenuItem("Open AppData Folder");
            op1.Click += Op1_Click;
            _cmsOptions.Items.Add(op1);

            ToolStripMenuItem op2 = new ToolStripMenuItem("Paste Clipboard");
            op2.Click += Op2_Click;
            _cmsOptions.Items.Add(op2);


            ToolStripMenuItem op3 = new ToolStripMenuItem("Toggle Orientation");
            op3.Click += Op3_Click;
            _cmsOptions.Items.Add(op3);

            //ToolStripMenuItem op4 = new ToolStripMenuItem("Load Previous Image...");
            //op4.Click += Op4_Click;
            //_cmsOptions.Items.Add(op4);

            //ToolStripMenuItem op5 = new ToolStripMenuItem("Load Next Image...");
            //op5.Click += Op5_Click;
            //_cmsOptions.Items.Add(op5);

            ToolStripMenuItem op6 = new ToolStripMenuItem("Clear Image History...");
            op6.Click += Op6_Click;
            _cmsOptions.Items.Add(op6);

            ToolStripMenuItem op7 = new ToolStripMenuItem("Toggle Always On Top");
            op7.Click += Op7_Click;
            _cmsOptions.Items.Add(op7);
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case '1':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR1) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR1;

                        e.Handled = true;
                    }
                    break; 
                case '2':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR2) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR2;

                        e.Handled = true;
                    }
                    break; 
                case '3':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR3) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR3;

                        e.Handled = true;
                    }
                    break; 
                case '4':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR4) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR4;

                        e.Handled = true;
                    }
                    break; 
                case '5':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR5) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR5;

                        e.Handled = true;
                    }
                    break; 
                case '6':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR6) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR6;

                        e.Handled = true;
                    }
                    break; 
                case '7':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR7) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR7;

                        e.Handled = true;
                    }
                    break; 
                case '8':
                    if (ColorMode.Instance.Get != EColorMode.NO_IMG)
                    {
                        if (ColorMode.Instance.Get == EColorMode.COLOR8) ColorMode.Instance.Set = EColorMode.NONE;
                        else ColorMode.Instance.Set = EColorMode.COLOR8;

                        e.Handled = true;
                    }
                    break;
            }

            
            
            
            base.OnKeyPress(e);



        }

        private void Op7_Click(object? sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void Op6_Click(object? sender, EventArgs e)
        {
            SavedImages.Instance.ClearMemory();
        }

        private void Op5_Click(object? sender, EventArgs e)
        {
            //_ucCnva.PasteClipboard(SavedImages.Instance.GetNextImage.ImageFile);
            SavedImages.Instance.LoadNextImage();
        }

        private void Op4_Click(object? sender, EventArgs e)
        {

            //_ucCnva.PasteClipboard(SavedImages.Instance.GetPreviousImage.ImageFile);
            SavedImages.Instance.LoadPreviousImage();
        }



        private void Op3_Click(object? sender, EventArgs e)
        {

            _cmsOptions.Hide();

            Program.ToggleAppOrient = true;

            base.Close();
            base.Dispose();

            return;

        }







        #endregion

        #endregion

        #region PROTECTED



        #endregion

        #region PRIVATE

        #region METHODS

        #region EVENTS


        private void Op2_Click(object? sender, EventArgs e)
        {
            PasteClipboard();
            _cmsOptions.Close();

        }
        private void Op1_Click(object? sender, EventArgs e)
        {

            LibUtil.DirectoryUtl.OpenDirectory(Program.appDataFolder, "Config.xml");

            _cmsOptions.Hide();
        }

        private void _ucCmd_OpenMenu(object? sender, OpenMenuEventArgs e)
        {

            _cmsOptions.Show(e.MouseLocation);

        }

        private void _ucCnva_ColorPicked(object? sender, Classes.ColorPickedEventArgs e)
        {
            _ucCmd.ColorPicked(e.PickedColor, e.ImageCoordinates);
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

            PasteClipboard();

        }
        private void FrmMain_Load(object? sender, EventArgs e)
        {

            if (Program.Debug)
                DbgWindow.Instance.Show();

        }


        #endregion

        private void PasteClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                Image? image = Clipboard.GetImage();

                if (image != null)
                {

                    //_ucCnva.PasteClipboard(SavedImages.Instance.LoadNewImage(new SavedImages.ImageSave((Image)image)));

                    SavedImages.Instance.LoadNewImage(new SavedImages.ImageSave((Image)image));

                    //_ucCnva.PasteClipboard(image);

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

        #region VARIABLES

        #region STATIC

        private static UserInterface _instance;
        private static EAppOrientation _appOrient;

        #endregion

        #endregion

        #region ENUM

        #endregion

        #endregion









    }

}
