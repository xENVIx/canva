
using canva;
using canva.ENUM;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

using canva.Classes;
using canva.DAT;

namespace canva.UI_ELEMENTS
{
    public partial class UCCommand : UserControl
    {


        #region PUBLIC

        #region EVENT

        public event EventHandler<OpenMenuEventArgs>? OpenMenu;

        #endregion

        #region VARIABLES

        #region OVERRIDE

        public override Color BackColor { get => base.BackColor; set { } }

        #endregion

        #endregion

        #region METHODS

        public void ColorPicked(Color color, Point point)
        {

            switch (ColorMode.Instance.Get)
            {
                case EColorMode.COLOR1: ColorPicked1(color); break;
                case EColorMode.COLOR2: ColorPicked2(color); break;
                case EColorMode.COLOR3: ColorPicked3(color); break;
                case EColorMode.COLOR4: ColorPicked4(color); break;
                case EColorMode.COLOR5: ColorPicked5(color); break;
                case EColorMode.COLOR6: ColorPicked6(color); break;
                case EColorMode.COLOR7: ColorPicked7(color); break;
                case EColorMode.COLOR8: ColorPicked8(color); break;

                default: break;

            }


        }

        #endregion

        #region CONSTRUCTORS

        public UCCommand()
        {
            InitializeComponent();

            ColorMode.Instance.ColorModeChanged += Instance_ColorModeChanged;


            UpdateColorMode(ColorMode.Instance.Get);


            this._btnColor1.MouseClick += _btnColor1_Click;
            this._btnColor2.MouseClick += _btnColor2_Click;
            this._btnColor3.MouseClick += _btnColor3_Click;
            this._btnColor4.MouseClick += _btnColor4_Click;
            this._btnColor5.MouseClick += _btnColor5_Click;
            this._btnColor6.MouseClick += _btnColor6_Click;
            this._btnColor7.MouseClick += _btnColor7_Click;
            this._btnColor8.MouseClick += _btnColor8_Click;


            this.MouseClick += UCCommand_MouseClick;

            this._pnlColor1.MouseClick += UCCommand_MouseClick;
            this._pnlColor2.MouseClick += UCCommand_MouseClick;
            this._pnlColor3.MouseClick += UCCommand_MouseClick;
            this._pnlColor4.MouseClick += UCCommand_MouseClick;
            this._pnlColor5.MouseClick += UCCommand_MouseClick;
            this._pnlColor6.MouseClick += UCCommand_MouseClick;
            this._pnlColor7.MouseClick += UCCommand_MouseClick;
            this._pnlColor8.MouseClick += UCCommand_MouseClick;

            this._tbColor1.MouseClick += UCCommand_MouseClick;
            this._tbColor2.MouseClick += UCCommand_MouseClick;
            this._tbColor3.MouseClick += UCCommand_MouseClick;
            this._tbColor4.MouseClick += UCCommand_MouseClick;
            this._tbColor5.MouseClick += UCCommand_MouseClick;
            this._tbColor6.MouseClick += UCCommand_MouseClick;
            this._tbColor7.MouseClick += UCCommand_MouseClick;
            this._tbColor8.MouseClick += UCCommand_MouseClick;


            this._tbColor1.Click += _tbColor1_Click;
            this._tbColor2.Click += _tbColor2_Click;
            this._tbColor3.Click += _tbColor3_Click;
            this._tbColor4.Click += _tbColor4_Click;

            this._tbColor5.Click += _tbColor5_Click;
            this._tbColor6.Click += _tbColor6_Click;
            this._tbColor7.Click += _tbColor7_Click;
            this._tbColor8.Click += _tbColor8_Click;

            this.MouseMove += UCCommand_MouseMove;

            base.BackColor = Config.Instance.BackgroundColor;


            _copiedOverlayTimer.Interval = 30;
            _copiedOverlayTimer.Elapsed += (s, e) =>
            {

                this.Invoke(new Action(() =>
                {
                    double elapsed = (DateTime.Now - _copiedOverlayStart).TotalMilliseconds;
                    double duration = 1000.0;

                    if (elapsed >= duration)
                    {
                        _copiedOverlayTimer.Stop();
                        _copiedOverlay.Hide();
                        return;
                    }

                    float progress = (float)(elapsed / duration);
                    _copiedOverlay.Scale = 1f + progress * 1.5f;
                    _copiedOverlay.Alpha = 1f - progress;
                    _copiedOverlay.Invalidate();
                }));
            };

        }

        

        








        #endregion

        #endregion

        #region PRIVATE

        #region VARIABLES

        private OverlayForm _copiedOverlay = new OverlayForm();
        private DateTime _copiedOverlayStart;
        private System.Timers.Timer _copiedOverlayTimer = new System.Timers.Timer();
        private Point _mouseLoc = new Point();

        #endregion

        #region METHODS

        #region EVENTS

        private void UCCommand_MouseMove(object? sender, MouseEventArgs e)
        {
            _mouseLoc = e.Location;
        }


        private void _tbColor8_Click(object? sender, EventArgs e)
        {
            if (_tbColor8.Text == "") return;

            try
            {

                Clipboard.Clear();
                Clipboard.SetText(_tbColor8.Text);
            }
            catch (Exception ex)
            {
                return;
            }

            StartCopiedAnimation(_tbColor8);
        }

        private void _tbColor7_Click(object? sender, EventArgs e)
        {
            if (_tbColor7.Text == "") return;

            try
            {

                Clipboard.Clear();
                Clipboard.SetText(_tbColor7.Text);
            }
            catch (Exception ex)
            {
                return;
            }

            StartCopiedAnimation(_tbColor7);
        }

        private void _tbColor6_Click(object? sender, EventArgs e)
        {
            if (_tbColor6.Text == "") return;

            try
            {

                Clipboard.Clear();
                Clipboard.SetText(_tbColor6.Text);
            }
            catch (Exception ex)
            {
                return;
            }

            StartCopiedAnimation(_tbColor6);
        }

        private void _tbColor5_Click(object? sender, EventArgs e)
        {
            if (_tbColor5.Text == "") return;

            try
            {

                Clipboard.Clear();
                Clipboard.SetText(_tbColor5.Text);
            }
            catch (Exception ex)
            {
                return;
            }

            StartCopiedAnimation(_tbColor5);
        }
        private void _tbColor4_Click(object? sender, EventArgs e)
        {

            if (_tbColor4.Text == "") return;

            try
            {

                Clipboard.Clear();
                Clipboard.SetText(_tbColor4.Text);
            }
            catch (Exception ex)
            {
                return;
            }

            StartCopiedAnimation(_tbColor4);
        }

        private void _tbColor3_Click(object? sender, EventArgs e)
        {

            if (_tbColor3.Text == "") return;

            try
            {
                Clipboard.Clear();
                Clipboard.SetText(_tbColor3.Text);
            }
            catch (Exception ex)
            {
                return;
            }

            StartCopiedAnimation(_tbColor3);

        }

        private void _tbColor2_Click(object? sender, EventArgs e)
        {

            if (_tbColor2.Text == "") return;

            try
            {

                Clipboard.Clear();
                Clipboard.SetText(_tbColor2.Text);
            }
            catch (Exception ex)
            {
                return;
            }

            StartCopiedAnimation(_tbColor2);
        }

        private void _tbColor1_Click(object? sender, EventArgs e)
        {
            if (_tbColor1.Text == "") return;


            try
            {

                Clipboard.Clear();
                Clipboard.SetText(_tbColor1.Text);
            }
            catch (Exception ex)
            {
                return;
            }
            StartCopiedAnimation(_tbColor1);
        }

        private void UCCommand_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ColorMode.Instance.Get == EColorMode.NO_IMG || ColorMode.Instance.Get == EColorMode.NONE)
                {
                    // throw up yo hands
                    OpenMenu?.Invoke(this, new OpenMenuEventArgs(this.PointToScreen(e.Location)));
                }

                if (ColorMode.Instance.Get != EColorMode.NONE && ColorMode.Instance.Get != EColorMode.NO_IMG)
                    ColorMode.Instance.Set = EColorMode.NONE;

                
            }
        }
        private void Instance_ColorModeChanged(object? sender, ColorModeEventArgs e)
        {

            UpdateColorMode(e.ColorMode);
        
        }

        private void _btnColor8_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR8;
            }
            else UCCommand_MouseClick(sender, e);
        }

        private void _btnColor7_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR7;
            }
            else UCCommand_MouseClick(sender, e);
        }

        private void _btnColor6_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR6;
            }
            else UCCommand_MouseClick(sender, e);
        }

        private void _btnColor5_Click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Classes.ColorMode.Instance.Get == EColorMode.NO_IMG) return;

                ColorMode.Instance.Set = EColorMode.COLOR5;
            }
            else UCCommand_MouseClick(sender, e);
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


        private void UpdateColorMode(EColorMode? colorMode)
        {

            if (colorMode == null) return;

            switch (colorMode)
            {
                case EColorMode.NO_IMG: DisableAllButtons(); break;
                default: EnableButtonByMode((EColorMode)colorMode); break;

            }

        }

        private void StartCopiedAnimation(Control anchor)
        {
            if (!string.IsNullOrWhiteSpace(anchor.Text))
            {
                try
                {

                    _copiedOverlay.DisplayText = $"{anchor.Text}";
                    _copiedOverlayStart = DateTime.Now;

                    Point screenCenter = anchor.PointToScreen(new Point(
                        anchor.Width / 2,
                        -30
                    ));

                    _copiedOverlay.ShowAt(screenCenter);
                    _copiedOverlay.Scale = 1f;
                    _copiedOverlay.Alpha = 1f;

                    _copiedOverlayTimer.Start();
                }
                catch (Exception)
                {

                }
            }
        }

        public void ColorPicked1(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor1.Text = hex;
            _pnlColor1.BackColor = color;

            AppDat.Instance.Color1 = color;

        }
        public void ColorPicked2(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor2.Text = hex;
            _pnlColor2.BackColor = color;

            AppDat.Instance.Color2 = color;
        }
        public void ColorPicked3(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor3.Text = hex;
            _pnlColor3.BackColor = color;

            AppDat.Instance.Color3 = color;
        }
        public void ColorPicked4(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor4.Text = hex;
            _pnlColor4.BackColor = color;

            AppDat.Instance.Color4 = color;
        }
        
        public void ColorPicked5(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor5.Text = hex;
            _pnlColor5.BackColor = color;

            //AppDat.Instance.Color5 = color;
        }
        public void ColorPicked6(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor6.Text = hex;
            _pnlColor6.BackColor = color;

            //AppDat.Instance.Color6 = color;
        }
        public void ColorPicked7(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor7.Text = hex;
            _pnlColor7.BackColor = color;

            //AppDat.Instance.Color7 = color;
        }
        public void ColorPicked8(Color color)
        {
            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            _tbColor8.Text = hex;
            _pnlColor8.BackColor = color;

            //AppDat.Instance.Color8 = color;
        }

        private void DisableAllButtons()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
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
                case EColorMode.COLOR5: Enable5();      break;
                case EColorMode.COLOR6: Enable6();      break;
                case EColorMode.COLOR7: Enable7();      break;
                case EColorMode.COLOR8: Enable8();      break;
            }
        }

        private void EnableAll()
        {
            _btnColor1.SetButton(true, ButtonBitmaps.Instance.Enabled1);
            _btnColor2.SetButton(true, ButtonBitmaps.Instance.Enabled2);
            _btnColor3.SetButton(true, ButtonBitmaps.Instance.Enabled3);
            _btnColor4.SetButton(true, ButtonBitmaps.Instance.Enabled4);
            _btnColor5.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor6.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor7.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor8.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);

        }

        private void Enable1()
        {
            _btnColor1.SetButton(true, ButtonBitmaps.Instance.Enabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
        }
        private void Enable2()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(true, ButtonBitmaps.Instance.Enabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
        }
        private void Enable3()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(true, ButtonBitmaps.Instance.Enabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Disabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Disabled4);
        }
        private void Enable4()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(true, ButtonBitmaps.Instance.Enabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
        }
        private void Enable5()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Enabled4);
            _btnColor5.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
        }
        private void Enable6()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Enabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor6.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
        }
        private void Enable7()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Enabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor7.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor8.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
        }
        private void Enable8()
        {
            _btnColor1.SetButton(false, ButtonBitmaps.Instance.Disabled1);
            _btnColor2.SetButton(false, ButtonBitmaps.Instance.Disabled2);
            _btnColor3.SetButton(false, ButtonBitmaps.Instance.Disabled3);
            _btnColor4.SetButton(false, ButtonBitmaps.Instance.Enabled4);
            _btnColor5.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor6.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor7.SetButton(false); //, ButtonBitmaps.Instance.Enabled4);
            _btnColor8.SetButton(true); //, ButtonBitmaps.Instance.Enabled4);
        }

        #endregion



        #endregion

    }


}
