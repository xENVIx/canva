
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
            if (!string.IsNullOrWhiteSpace(anchor.Text))
            {
                Clipboard.SetText(anchor.Text);

                _copiedOverlay.DisplayText = "Copied";
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

        private OverlayForm _copiedOverlay = new OverlayForm();
        private DateTime _copiedOverlayStart;
        private System.Timers.Timer _copiedOverlayTimer = new System.Timers.Timer();

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


    public class OverlayForm : Form
    {
        public string DisplayText = "Copied";
        public float Scale = 1f;
        public float Alpha = 1f;

        public OverlayForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.LimeGreen; // fake key
            this.TransparencyKey = Color.LimeGreen;
            this.Width = 300;
            this.Height = 100;

            this.DoubleBuffered = true;
        }

        public void ShowAt(Point center)
        {
            this.Location = new Point(center.X - this.Width / 2, center.Y - this.Height / 2);
            this.Show();
            this.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Font font = new Font("Segoe UI", 14 * Scale, FontStyle.Bold))
            {
                SizeF size = g.MeasureString(DisplayText, font);
                PointF drawPt = new PointF(
                    (this.ClientSize.Width - size.Width) / 2,
                    (this.ClientSize.Height - size.Height) / 2
                );

                Color color = Color.FromArgb((int)(Alpha * 255), 0, 0, 0);
                using (Brush b = new SolidBrush(color))
                {
                    g.DrawString(DisplayText, font, b, drawPt);
                }
            }
        }
    }



}
