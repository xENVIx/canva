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
using System.Globalization;
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

        #region CONSTRUCTORS



        public UserInterface()
        {
            InitializeComponent();


            _menuStrip = new MenuStrip();
            _menuStrip.SuspendLayout();



            this.Controls.Add(_menuStrip);


            _menuStrip.ResumeLayout(false);

            if (_menuStripShown)
            {
                _menuStrip.Show();
                _menuStrip.Visible = false;
            }
            else
            {
                _menuStrip.Hide();
                _menuStrip.Visible = false;
            }


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

            //this._ucCmd.OpenMenu += _ucCmd_OpenMenu;


            _cms.Opening += _cms_Opening;
            



            foreach (E_CMS_OP op in typeof(E_CMS_OP).GetEnumValues())
            {
                ToolStripMenuItem? item = null;
                ToolStripMenuItem? item2 = null;
                switch (op)
                {
                    case E_CMS_OP.OPEN_APPDATA:
                        item = new ToolStripMenuItem("Open AppData Folder");
                        item.Click += _cmsItemAppDataClick;
                        item2 = new ToolStripMenuItem("Open AppData Folder");
                        item2.Click += _cmsItemAppDataClick;
                        break;
                    case E_CMS_OP.TOGGLE_ON_TOP:
                        item = new ToolStripMenuItem("Toggle Always On Top");
                        item.Click += _cmsItemToggleOnTopClick;
                        item2 = new ToolStripMenuItem("Toggle Always On Top");
                        item2.Click += _cmsItemToggleOnTopClick;
                        break;
                    case E_CMS_OP.PASTE_CLIPBOARD:
                        item = new ToolStripMenuItem("Paste Clipboard");
                        item.Click += _cmsItemPasteClipboardClick;
                        item2 = new ToolStripMenuItem("Paste Clipboard");
                        item2.Click += _cmsItemPasteClipboardClick;
                        break;
                    case E_CMS_OP.TOGGLE_ORIENT:
                        item = new ToolStripMenuItem("Toggle Orientation");
                        item.Click += _cmsItemToggleOrientClick;
                        item2 = new ToolStripMenuItem("Toggle Orientation");
                        item2.Click += _cmsItemToggleOrientClick;
                        break;
                    case E_CMS_OP.CLR_IMG_HISTORY:
                        item = new ToolStripMenuItem("Clear Image History");
                        item.Click += _cmsItemClearImageHistoryClick;
                        item2 = new ToolStripMenuItem("Clear Image History");
                        item2.Click += _cmsItemClearImageHistoryClick;
                        break;
                    case E_CMS_OP.TOGGLE_CACHE_IMAGES:
                        item = new ToolStripMenuItem("Toggle Image Cache");
                        item.Click += _cmsItemToggleImageCacheClick;
                        item2 = new ToolStripMenuItem("Toggle Image Cache");
                        item2.Click += _cmsItemToggleImageCacheClick;
                        break;
                    case E_CMS_OP.EXIT_APP:
                        item = new ToolStripMenuItem("Exit...");
                        item.Click += _cmsItemExitAppClicked;
                        item2 = new ToolStripMenuItem("Exit...");
                        item2.Click += _cmsItemExitAppClicked;
                        break;
                }


                if (item == null || item2 == null) continue;

                

                item.Tag = op;
                item2.Tag = op;

                _menuStripOptionFile.DropDownItems.Add((ToolStripMenuItem)item);
                _cms.Items.Add((ToolStripMenuItem)item2);
            }

            _menuStripOptionFile.DropDown.Opening += _menuStripOptionFile_Opening;


            _menuStrip.Items.Add(_menuStripOptionFile);



        }

        private void _cms_Opening(object? sender, CancelEventArgs e)
        {
            MenuOpening(_cms.Items);
        }

        protected override void WndProc(ref Message m)
        {
            //const int WM_LBUTTONDOWN = 0x0201;
            const int WM_RBUTTONDOWN = 0x0204;
            const int WM_PARENTNOTIFY = 0x0210;

            Console.WriteLine("LOG WndProc");
            Console.WriteLine(m.Msg.ToString());


            if (m.Msg == WM_PARENTNOTIFY)
            {
                int eventType = m.WParam.ToInt32() & 0xFFFF;
                if (eventType == WM_RBUTTONDOWN)
                {
                    Point clientPos = new Point(m.LParam.ToInt32());
                    Point screenPos = this.PointToScreen(clientPos);

                    Console.WriteLine($"Click detected at {screenPos}");

                    if (ColorMode.Instance.Get == EColorMode.NONE || ColorMode.Instance.Get == EColorMode.NO_IMG)
                    {
                        //ShowAsContextMenu(screenPos);
                        _cms.Show(screenPos);

                    }
                }
            }


            base.WndProc(ref m);
        }

        private ContextMenuStrip _cms = new ContextMenuStrip();
        private void ShowAsContextMenu(Point location)
        {
            
        }



        private void _cmsItemExitAppClicked(object? sender, EventArgs e)
        {

            CloseApp();

        }

        private void MenuOpening(ToolStripItemCollection items)
        {

            foreach (ToolStripMenuItem item in items)
            {
                if (item == null || item.Tag == null) continue;

                if (item.Tag.GetType() == typeof(E_CMS_OP))
                {
                    E_CMS_OP tag = (E_CMS_OP)item.Tag;
                    String text = "";
                    switch (tag)
                    {
                        case E_CMS_OP.TOGGLE_CACHE_IMAGES:
                            if (Config.Instance.CacheImages) text = "Disable";
                            else text = "Enable";

                            item.Text = $"{text} Cached Images";
                            break;

                        case E_CMS_OP.TOGGLE_ORIENT:
                            switch (Config.Instance.AppOrientation)
                            {
                                case EAppOrientation.HORIZONTAL:
                                    text = "Switch To Vertical";
                                    break;
                                case EAppOrientation.VERTICAL:
                                    text = "Switch To Horizontal";
                                    break;
                                default: text = "err"; break;
                            }

                            item.Text = text;
                            break;

                        case E_CMS_OP.TOGGLE_ON_TOP:
                            if (Config.Instance.AlwaysOnTop) text = "Disable";
                            else text = "Enable";

                            item.Text = $"{text} Always On Top";

                            break;


                        default: continue;
                    }
                }
            }
        }

        private void _menuStripOptionFile_Opening(object? sender, CancelEventArgs e)
        {

            MenuOpening(_menuStripOptionFile.DropDownItems);
        }

        private void _cmsItemToggleImageCacheClick(object? sender, EventArgs e)
        {
            try
            {
                Config.Instance.CacheImages = !Config.Instance.CacheImages;
                Config.Instance.SaveData();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError($"Could Not Save Config Data: {ex.Message}");
            }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {

                if (_menuStripShown)
                {
                    _menuStrip.Hide();
                    _menuStrip.Visible = false;
                    _menuStripShown = false;
                }
                else
                {
                    _menuStrip.Show();
                    _menuStrip.Visible = true;
                    _menuStripShown = true;
                }

                e.Handled = true;
            }
            else
            {

                base.OnKeyDown(e);
            }
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

        private void _cmsItemToggleOnTopClick(object? sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;

            Config.Instance.AlwaysOnTop = this.TopMost;

            try
            {
                Config.Instance.SaveData();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError(ex);
            }
        }

        private void _cmsItemClearImageHistoryClick(object? sender, EventArgs e)
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



        private void _cmsItemToggleOrientClick(object? sender, EventArgs e)
        {

            Program.ToggleAppOrient = true;

            base.Close();
            base.Dispose();

            return;

        }







        #endregion

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

            Config.Instance.AppOrientation = _appOrient;

            try
            {
                Config.Instance.SaveData();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError(ex);
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

        #endregion

        #region PROTECTED



        #endregion

        #region PRIVATE

        #region ENUM
        private enum E_CMS_OP
        {

            PASTE_CLIPBOARD,
            TOGGLE_CACHE_IMAGES,

            TOGGLE_ON_TOP,
            TOGGLE_ORIENT,
            OPEN_APPDATA,
            

            CLR_IMG_HISTORY,

            EXIT_APP,
        }

        #endregion

        #region METHODS

        #region EVENTS


        private void _cmsItemPasteClipboardClick(object? sender, EventArgs e)
        {
            PasteClipboard();

        }
        private void _cmsItemAppDataClick(object? sender, EventArgs e)
        {

            LibUtil.DirectoryUtl.OpenDirectory(Program.appDataFolder, "Config.xml");

        }


        private void _ucCnva_ColorPicked(object? sender, Classes.ColorPickedEventArgs e)
        {
            _ucCmd.ColorPicked(e.PickedColor, e.ImageCoordinates);
        }

        private void _btnClose_Click(object? sender, EventArgs e)
        {

            CloseApp();

        }

        private void _btnPaste_Click(object? sender, EventArgs e)
        {

            PasteClipboard();

        }
        private void FrmMain_Load(object? sender, EventArgs e)
        {

            if (Program.Debug)
                DbgWindow.Instance.Show();


            if (Config.Instance.CacheImages && _initialInit)
            {

                List<Image> images = ImageCache.Instance.LoadCachedImages();

                if (images.Count > 0)
                {
                    for (int i = 0; i < images.Count; i++)
                    {
                        SavedImages.Instance.LoadNewImageOnStartup(images[i]);
                    }
                }

                _initialInit = false;
            }

        }


        #endregion

        private void CloseApp()
        {

            //if (MyMessageBox.ShowAskQuestion(this, "Do you want to close the app?", "Confirm Application Close") == DialogResult.Yes)
            //{
                this.Close();
                this.Dispose();
                return;
            //}

        }

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
        private static bool _initialInit = true;


        #endregion

        private ToolStripMenuItem _menuStripOptionFile = new ToolStripMenuItem("File");
        private MenuStrip _menuStrip = new MenuStrip();
        private bool _menuStripShown = false;

        #endregion

        #region ENUM

        #endregion

        #endregion









    }

}
