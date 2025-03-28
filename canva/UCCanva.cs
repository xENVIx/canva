
using canva;
using canva.ENUM;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace canva
{
    public partial class UCCanva : Form
    {

        // P/Invoke declarations
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private const int WM_NCPAINT = 0x85;
        private const int WM_SETTEXT = 0x000C;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCPAINT)
            {
                // Get the device context for the window’s non-client area
                IntPtr hDC = GetWindowDC(this.Handle);
                if (hDC != IntPtr.Zero)
                {
                    using (Graphics g = Graphics.FromHdc(hDC))
                    {
                        // Prepare title text settings
                        string title = this.Text;
                        Font titleFont = this.Font; // You might choose a different font
                        SizeF textSize = g.MeasureString(title, titleFont);

                        // Calculate the center position of the title bar
                        int x = (this.Width - (int)textSize.Width) / 2;
                        // The Y value might need tweaking depending on the OS and theme
                        int y = 5;

                        // Clear the area (optional, depending on your needs)
                        // g.FillRectangle(SystemBrushes.ActiveCaption, new Rectangle(x, y, (int)textSize.Width, (int)textSize.Height));

                        // Draw the title text
                        g.DrawString(title, titleFont, SystemBrushes.ActiveCaptionText, x, y);
                    }
                    ReleaseDC(this.Handle, hDC);
                }
            }
            // Handle WM_SETTEXT if needed to update the caption on text change
        }

        #region PUBLIC

        #region VARIABLES

        #region STATIC

        public static UCCanva Instance { get { return _instance; } }

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

        private UCCanva()
        {
            InitializeComponent();

            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream s = asm.GetManifestResourceStream("canva.ico.duck1.ico"))
            {
                this.Icon = new Icon(s);
            }


            _btnBmps = new ButtonBitmaps();
            _btnColor1.BackgroundImage = _btnBmps.Enabled1;
            _btnColor2.BackgroundImage = _btnBmps.Enabled2;
            _btnColor3.BackgroundImage = _btnBmps.Enabled3;
            _btnColor4.BackgroundImage = _btnBmps.Enabled4;



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



            UpdateTextPosition();


            this.Text = "♥ C A N V A ♥";


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
                try
                {
                    Clipboard.SetText(anchor.Text);

                    _copiedOverlay.DisplayText = "  Copied\n\tTo\nClipboard";
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

                _btnColor1.BackgroundImage = _btnBmps.Disabled1;
                _btnColor2.BackgroundImage = _btnBmps.Disabled2;
                _btnColor3.BackgroundImage = _btnBmps.Disabled3;
                _btnColor4.BackgroundImage = _btnBmps.Disabled4;

            }
            else if (e.ColorMode == EColorMode.COLOR1)
            {
                _btnColor1.Enabled = true;
                _btnColor2.Enabled = false;
                _btnColor3.Enabled = false;
                _btnColor4.Enabled = false;


                _btnColor1.BackgroundImage = _btnBmps.Enabled1;
                _btnColor2.BackgroundImage = _btnBmps.Disabled2;
                _btnColor3.BackgroundImage = _btnBmps.Disabled3;
                _btnColor4.BackgroundImage = _btnBmps.Disabled4;


                _cnva.SetCursor(DripperToolCursor);

            }
            else if (e.ColorMode == EColorMode.COLOR2)
            {
                _btnColor1.Enabled = false;
                _btnColor2.Enabled = true;
                _btnColor3.Enabled = false;
                _btnColor4.Enabled = false;


                _btnColor1.BackgroundImage = _btnBmps.Disabled1;
                _btnColor2.BackgroundImage = _btnBmps.Enabled2;
                _btnColor3.BackgroundImage = _btnBmps.Disabled3;
                _btnColor4.BackgroundImage = _btnBmps.Disabled4;

                _cnva.SetCursor(DripperToolCursor);

            }
            else if (e.ColorMode == EColorMode.COLOR3)
            {
                _btnColor1.Enabled = false;
                _btnColor2.Enabled = false;
                _btnColor3.Enabled = true;
                _btnColor4.Enabled = false;


                _btnColor1.BackgroundImage = _btnBmps.Disabled1;
                _btnColor2.BackgroundImage = _btnBmps.Disabled2;
                _btnColor3.BackgroundImage = _btnBmps.Enabled3;
                _btnColor4.BackgroundImage = _btnBmps.Disabled4;

                _cnva.SetCursor(DripperToolCursor);
            }
            else if (e.ColorMode == EColorMode.COLOR4)
            {
                _btnColor1.Enabled = false;
                _btnColor2.Enabled = false;
                _btnColor3.Enabled = false;
                _btnColor4.Enabled = true;


                _btnColor1.BackgroundImage = _btnBmps.Disabled1;
                _btnColor2.BackgroundImage = _btnBmps.Disabled2;
                _btnColor3.BackgroundImage = _btnBmps.Disabled3;
                _btnColor4.BackgroundImage = _btnBmps.Enabled4;

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

            //_dripperTool = CustomCursor.Instance.LoadCustomCursor("canva.Cursors.dropper.png", 0, 23);
            _dripperTool = CustomCursor.Instance.LoadCustomCursor("canva.Icons.drip_drip_4.png", 5, 25);


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


        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }


        #endregion

        #region VARIABLES

        #region STATIC

        private static UCCanva _instance = new UCCanva();

        #endregion


        private bool _imgLoaded = false;
        private ColorMode _colorMode = new ColorMode();

        private Cursor? _dripperTool = null;

        private OverlayForm _copiedOverlay = new OverlayForm();
        private DateTime _copiedOverlayStart;
        private System.Timers.Timer _copiedOverlayTimer = new System.Timers.Timer();

        private ButtonBitmaps _btnBmps;

        #endregion

        #region ENUM



        #endregion

        #endregion

        private void _btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the app?", "Yes / No Please", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void _btnPaste_Click(object sender, EventArgs e)
        {
            _cnva.PasteClipboard();
                
        }

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


    internal class ButtonBitmaps
    {

        public Bitmap Enabled1 { get { if (_enabled1 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled1; } }
        public Bitmap Enabled2 { get { if (_enabled2 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled2; } }
        public Bitmap Enabled3 { get { if (_enabled3 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled3; } }
        public Bitmap Enabled4 { get { if (_enabled4 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_enabled4; } }
        public Bitmap Disabled1 { get { if (_disabled1 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled1; } }
        public Bitmap Disabled2 { get { if (_disabled2 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled2; } }
        public Bitmap Disabled3 { get { if (_disabled3 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled3; } }
        public Bitmap Disabled4 { get { if (_disabled4 == null) throw new ArgumentNullException("Icon Is Null"); return (Bitmap)_disabled4; } }


        //public static ButtonBitmaps Instance { get { return _instance; } }

        public ButtonBitmaps()
        {

            try
            {
                _enabled1 = GetBitmapFromResource("canva.ico.ico1.ico");
                _enabled2 = GetBitmapFromResource("canva.ico.ico2.ico");
                _enabled3 = GetBitmapFromResource("canva.ico.ico3.ico");
                _enabled4 = GetBitmapFromResource("canva.ico.ico4.ico");


                _disabled1 = GetBitmapFromResource("canva.ico.ic01.ico");
                _disabled2 = GetBitmapFromResource("canva.ico.ic02.ico");
                _disabled3 = GetBitmapFromResource("canva.ico.ic03.ico");
                _disabled4 = GetBitmapFromResource("canva.ico.ic04.ico");
            }
            catch { }


        }


        private Bitmap? GetBitmapFromResource(String resource)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream s = asm.GetManifestResourceStream(resource))
            {
                Icon ico = new Icon(s);
                return ico.ToBitmap();
            }

        }



        private Bitmap? _disabled1;
        private Bitmap? _disabled2;
        private Bitmap? _disabled3;
        private Bitmap? _disabled4;

        private Bitmap? _enabled1;
        private Bitmap? _enabled2;
        private Bitmap? _enabled3;
        private Bitmap? _enabled4;

        //private static ButtonBitmaps _instance = new ButtonBitmaps();

    }


    internal class CustomFont
    {

        public Font? font;

        internal CustomFont()
        {


            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream fontStream = asm.GetManifestResourceStream("canva.ttf.stencilla.ttf"))
            {
                if (fontStream != null)
                {
                    byte[] fontData = new byte[fontStream.Length];
                    fontStream.Read(fontData, 0, (int)fontStream.Length);

                    // Allocate memory and copy the font data
                    IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                    Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                    // Create the font collection
                    PrivateFontCollection pfc = new PrivateFontCollection();
                    pfc.AddMemoryFont(fontPtr, fontData.Length);

                    // Free the memory
                    Marshal.FreeCoTaskMem(fontPtr);

                    // Use the font
                    font = new Font(pfc.Families[0], 12f, FontStyle.Bold, GraphicsUnit.Pixel); // Set your desired size

                }



            }

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
        public string DisplayText = "El Copy";
        public float Scale = 1f;
        public float Alpha = 1f;

        public OverlayForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.HotPink; // fake key
            this.TransparencyKey = Color.HotPink;
            this.Width = 500;
            this.Height = 300;

            

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


            CustomFont cusFont = new CustomFont();


            this.Font = cusFont.font;  // Apply to the form, or use for a specific control


            using (Font font = cusFont.font)
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
