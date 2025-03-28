
using canva;
using canva.ENUM;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

using canva.Classes;

namespace canva.UI_ELEMENTS
{
    public partial class UCCommand : UserControl
    {


        #region PUBLIC

        #region CONSTRUCTORS

        public UCCommand()
        {
            InitializeComponent();

            ColorMode.Instance.ColorModeChanged += Instance_ColorModeChanged;

            DisableAllButtons();


            this._btnColor1.MouseClick += _btnColor1_Click;
            this._btnColor2.MouseClick += _btnColor2_Click;
            this._btnColor3.MouseClick += _btnColor3_Click;
            this._btnColor4.MouseClick += _btnColor4_Click;


            this.MouseClick += UCCommand_MouseClick;

            this._pnlColor1.MouseClick += UCCommand_MouseClick;
            this._pnlColor2.MouseClick += UCCommand_MouseClick;
            this._pnlColor3.MouseClick += UCCommand_MouseClick;
            this._pnlColor4.MouseClick += UCCommand_MouseClick;
            this._tbColor1.MouseClick += UCCommand_MouseClick;
            this._tbColor2.MouseClick += UCCommand_MouseClick;
            this._tbColor3.MouseClick += UCCommand_MouseClick;
            this._tbColor4.MouseClick += UCCommand_MouseClick;

        }





        #endregion

        #endregion

        #region PRIVATE

        #region METHODS

        #region EVENTS

        private void UCCommand_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ColorMode.Instance.Get != EColorMode.NONE && ColorMode.Instance.Get != EColorMode.NO_IMG)
                    ColorMode.Instance.Set = EColorMode.NONE;

                if (ColorMode.Instance.Get == EColorMode.NO_IMG || ColorMode.Instance.Get == EColorMode.NONE)
                {
                    // throw up yo hands
                }
            }
        }
        private void Instance_ColorModeChanged(object? sender, ColorModeEventArgs e)
        {

            if (e.ColorMode == null) return;

            switch (e.ColorMode)
            {
                case EColorMode.NO_IMG: DisableAllButtons(); break;
                default: EnableButtonByMode((EColorMode)e.ColorMode); break;
                    
            }
        
        }


        private void _btnColor4_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR4;
            }
            else UCCommand_MouseClick(sender, e);
        }

        private void _btnColor3_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR3;
            }
            else UCCommand_MouseClick(sender, e);
        }

        private void _btnColor2_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR2;
            }
            else UCCommand_MouseClick(sender, e);
        }

        private void _btnColor1_Click(object? sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR1;
            }
            else UCCommand_MouseClick(sender, e);
        }


        #endregion

        private void DisableAllButtons()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
        }

        private void EnableButtonByMode(EColorMode colorMode)
        {
            switch (colorMode)
            {
                case EColorMode.NONE:   EnableAll();    break;
                case EColorMode.COLOR1: Enable1();      break;
                case EColorMode.COLOR2: Enable2();      break;
                case EColorMode.COLOR3: Enable3();      break;
                case EColorMode.COLOR4: Enable4();      break;
            }
        }

        private void EnableAll()
        {
            _btnColor1.SetButton(true, ButtonBitmaps.Instance.Enabled1);
            _btnColor2.SetButton(true, ButtonBitmaps.Instance.Enabled2);
            _btnColor3.SetButton(true, ButtonBitmaps.Instance.Enabled3);
            _btnColor4.SetButton(true, ButtonBitmaps.Instance.Enabled4);

        }

        private void Enable1()
        {
            _btnColor1.SetButton(true, ButtonBitmaps.Instance.Enabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
        }
        private void Enable2()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(true, ButtonBitmaps.Instance.Enabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
        }
        private void Enable3()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(true, ButtonBitmaps.Instance.Enabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
        }
        private void Enable4()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(true, ButtonBitmaps.Instance.Enabled4);
        }

        #endregion

        #endregion

    }


}
