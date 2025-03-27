
using canva.ENUM;

namespace canva
{
    public partial class UserInterface : Form
    {
        #region PUBLIC

        #region VARIABLES

        #region STATIC

        public static UserInterface Instance { get { return _instance; } }

        #endregion

        public Cursor DripperToolCursor { get { if (_dripperTool == null) return Cursors.Default; return (Cursor)_dripperTool; } }

        #endregion

        #region METHODS

        public bool ImageLoaded { set { if (value) _colorMode.Set = EColorMode.NONE; else _colorMode.Set = EColorMode.NO_IMG; _imgLoaded = value; } }

        public void SetColorModeNone() { _colorMode.Set = EColorMode.NONE; } 
        public EColorMode GetColorMode { get { return _colorMode.Get; } }

        #endregion

        #endregion



        #region PRIVATE

        #region CONSTRUCTORS

        private UserInterface()
        {
            InitializeComponent();



            this.KeyDown += UserInterface_KeyDown;
            this.KeyUp += UserInterface_KeyUp;
            this.Load += UserInterface_Load;

            _btnColor1.Click += _btnColor1_Click;
            _btnColor2.Click += _btnColor2_Click;
            _btnColor3.Click += _btnColor3_Click;
            _btnColor4.Click += _btnColor4_Click;

            _colorMode.ColorModeChanged += _colorMode_ColorModeChanged;


            _btnColor1.Enabled = false;
            _btnColor2.Enabled = false;
            _btnColor3.Enabled = false; 
            _btnColor4.Enabled = false;


            this.MouseClick += UserInterface_MouseClick;


            _cnva.ColorPicked += _cnva_ColorPicked;




            _tbColor1.Click += _tbColor1_Enter;
            _tbColor2.Click += _tbColor2_Enter;
            _tbColor3.Click += _tbColor3_Enter;
            _tbColor4.Click += _tbColor4_Enter;


            


            _copiedLabel.Text = "Copied!";
            _copiedLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            _copiedLabel.AutoSize = true;
            _copiedLabel.Visible = false;
            _copiedLabel.BackColor = Color.Transparent;
            _copiedLabel.ForeColor = Color.FromArgb(255, 0, 0, 0);
            _copiedLabel.Parent = this;
            _copiedLabel.BringToFront();
            Controls.Add(_copiedLabel);

            _copiedAnimTimer.Interval = 30;
            _copiedAnimTimer.Elapsed += _copiedAnimTimer_Elapsed;

            _copiedLabel.BackColor = Color.Transparent;

        }

        private void _copiedAnimTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {

            this.Invoke(new Action(() =>
            {

                _copiedLabel.BringToFront();
                double elapsed = (DateTime.Now - _copiedStartTime).TotalMilliseconds;
                double duration = 2000.0; // 2 seconds

                if (elapsed >= duration)
                {
                    _copiedAnimTimer.Stop();
                    _copiedLabel.Visible = false;
                    return;
                }

                float progress = (float)(elapsed / duration);
                _copiedScale = 1f + progress * 1.5f; // grows 1x to 2.5x
                _copiedAlpha = 1f - progress;        // fades from 1 to 0

                int alpha = (int)(_copiedAlpha * 255);
                if (alpha < 0) alpha = 0;

                _copiedLabel.ForeColor = Color.FromArgb(alpha, 0, 0, 0);

                float newSize = 14 * _copiedScale;
                _copiedLabel.Font = new Font("Segoe UI", newSize, FontStyle.Bold);

                _copiedLabel.Left = (this.ClientSize.Width - _copiedLabel.Width) / 2;
            }
            ));
        }

        private void _tbColor4_Enter(object? sender, EventArgs e)
        {
            if (_tbColor4.Text != "")
            {
                Clipboard.SetText(_tbColor4.Text);
                StartCopiedAnimation(_tbColor4);
            }
        }

        private void _tbColor3_Enter(object? sender, EventArgs e)
        {
            if (_tbColor3.Text != "")
            {
                Clipboard.SetText(_tbColor3.Text);

                StartCopiedAnimation(_tbColor3);
            }

        }

        private void _tbColor2_Enter(object? sender, EventArgs e)
        {
            if (_tbColor2.Text != "")
            {
                Clipboard.SetText(_tbColor2.Text);

                StartCopiedAnimation(_tbColor2);
            }
        }

        private void StartCopiedAnimation(Control anchor)
        {
            _copiedScale = 1f;
            _copiedAlpha = 1f;
            _copiedStartTime = DateTime.Now;

            _copiedLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            _copiedLabel.Visible = true;

            Point center = new Point(
                anchor.Left + (anchor.Width - _copiedLabel.Width) / 2,
                anchor.Top - 30
            );

            _copiedLabel.Location = center;
            _copiedAnimTimer.Start();
        }

        private void _tbColor1_Enter(object? sender, EventArgs e)
        {
            if (_tbColor1.Text != "")
            {
                Clipboard.SetText(_tbColor1.Text);

                StartCopiedAnimation(_tbColor1);
            }
        }

        private void _cnva_ColorPicked(object? sender, ColorPickedEventArgs e)
        {

            Color color = e.PickedColor;

            string hex = $"#{color.R:X2}{color.G:X2}{color.B:X2}";

            switch (_colorMode.Get)
            {
                case EColorMode.COLOR1: 
                    _pnlColor1.BackColor = color;
                    _tbColor1.Text = hex;
                    break;
                case EColorMode.COLOR2: 
                    _pnlColor2.BackColor = color;
                    _tbColor2.Text = hex;
                    break;
                case EColorMode.COLOR3: 
                    _pnlColor3.BackColor = color;
                    _tbColor3.Text = hex;
                    break;
                case EColorMode.COLOR4: 
                    _pnlColor4.BackColor = color;
                    _tbColor4.Text = hex;
                    break;

            }

        }

        private void UserInterface_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _colorMode.Set = EColorMode.NONE;
            }
        }

        private void _btnColor4_Click(object? sender, EventArgs e)
        {
            _colorMode.Set = EColorMode.COLOR4;
        }

        private void _btnColor3_Click(object? sender, EventArgs e)
        {
            _colorMode.Set = EColorMode.COLOR3;
        }

        private void _btnColor2_Click(object? sender, EventArgs e)
        {
            _colorMode.Set = EColorMode.COLOR2;
        }

        private void _btnColor1_Click(object? sender, EventArgs e)
        {
            _colorMode.Set = EColorMode.COLOR1;
        }

        private void _colorMode_ColorModeChanged(object? sender, ColorModeEventArgs e)
        {
            if (e.ColorMode == EColorMode.NONE)
            {
                _btnColor1.Enabled = true;
                _btnColor2.Enabled = true;
                _btnColor3.Enabled = true;
                _btnColor4.Enabled = true;

                _cnva.SetCursor(Cursors.Default);

            }
            else if (e.ColorMode == EColorMode.COLOR1)
            {
                _btnColor1.Enabled = true;
                _btnColor2.Enabled = false;
                _btnColor3.Enabled = false;
                _btnColor4.Enabled = false;


                _cnva.SetCursor(DripperToolCursor);

            }
            else if (e.ColorMode == EColorMode.COLOR2)
            {
                _btnColor1.Enabled = false;
                _btnColor2.Enabled = true;
                _btnColor3.Enabled = false;
                _btnColor4.Enabled = false;

                _cnva.SetCursor(DripperToolCursor);

            }
            else if (e.ColorMode == EColorMode.COLOR3)
            {
                _btnColor1.Enabled = false;
                _btnColor2.Enabled = false;
                _btnColor3.Enabled = true;
                _btnColor4.Enabled = false;

                _cnva.SetCursor(DripperToolCursor);
            }
            else if (e.ColorMode == EColorMode.COLOR4)
            {
                _btnColor1.Enabled = false;
                _btnColor2.Enabled = false;
                _btnColor3.Enabled = false;
                _btnColor4.Enabled = true;

                _cnva.SetCursor(DripperToolCursor);
            }




            //if (e.ColorMode != EColorMode.NONE && e.ColorMode != EColorMode.NO_IMG)
            //{
            //    _zoomBox.Visible = true;
            //    _cnva.MouseMove += _cnva_MouseMove;
            //}
            //else
            //{
            //    _zoomBox.Visible = false;
            //    _cnva.MouseMove -= _cnva_MouseMove;
            //}
            
        }

        private void _cnva_MouseMove(object? sender, MouseEventArgs e)
        {
            
        }






        #endregion

        #region METHODS

        #region EVENTS

        private void UserInterface_Load(object? sender, EventArgs e)
        {

            _dripperTool = CustomCursor.Instance.LoadCustomCursor("canva.Cursors.dropper.png", 0, 23);

            //_dripperTool = CustomCursor.CreateCursorFromBitmap(new Bitmap("Cursors/dripper.png"), 2, 2);

            if (Program.Debug)
                DbgWindow.Instance.Show();






        }

        private void UserInterface_KeyUp(object? sender, KeyEventArgs e)
        {

            _cnva.CyotekCanva_KeyUp(sender, e);
        }

        private void UserInterface_KeyDown(object? sender, KeyEventArgs e)
        {
            _cnva.CyotekCanva_KeyDown(sender, e);
        }

        #endregion

        

        #endregion

        #region VARIABLES

        #region STATIC

        private static UserInterface _instance = new UserInterface();

        #endregion


        private bool _imgLoaded = false;
        private ColorMode _colorMode = new ColorMode();

        private Cursor? _dripperTool = null;

        
        private Label _copiedLabel = new Label();
        private System.Timers.Timer _copiedAnimTimer = new System.Timers.Timer();
        private float _copiedScale = 1f;
        private float _copiedAlpha = 1f;
        private DateTime _copiedStartTime;

        #endregion

        #region ENUM



        #endregion

        #endregion

        private struct ColorMode
        {

            public event EventHandler<ColorModeEventArgs>? ColorModeChanged;

            public EColorMode Set
            {
                set
                {
                    //if (_colorMode == EColorMode.NO_IMG && value != EColorMode.NONE) return;

                    if (_colorMode != value)
                    {
                        ColorModeChanged?.Invoke(this, new ColorModeEventArgs(value));
                        _colorMode = value;
                    
                    }
                }
            }

            public EColorMode Get
            {
                get { return _colorMode; }
            }

            public ColorMode()
            {

            }

            private EColorMode _colorMode = EColorMode.NO_IMG;

        }


    }



    internal class ColorModeEventArgs : EventArgs
    {

        public EColorMode? ColorMode { get { return _colorMode; } set { _colorMode = value; } }

        internal ColorModeEventArgs(EColorMode? colorMode = null) : base()
        {

            _colorMode = colorMode;

        }


        private EColorMode? _colorMode;



    }


    



}
