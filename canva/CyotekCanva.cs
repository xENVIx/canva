using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cyotek.Windows.Forms;


namespace canva
{

    public class ColorPickedEventArgs : EventArgs
    {
        public Color PickedColor { get; }
        public Point ImageCoordinates { get; }

        public ColorPickedEventArgs(Color color, Point coords)
        {
            PickedColor = color;
            ImageCoordinates = coords;
        }
    }

    public partial class CyotekCanva : ImageBox
    {


        public event EventHandler<ColorPickedEventArgs>? ColorPicked;



        public void SetCursor(Cursor cursor)
        {
            _curCur = cursor;
            this.Cursor = _curCur;


            base.CursorChanged += CyotekCanva_CursorChanged;

        }

        private void CyotekCanva_CursorChanged(object? sender, EventArgs e)
        {

            if (_scrolling && this.Cursor == _scrollCursor) return;

            if (this.Cursor != _curCur) this.Cursor = _curCur;
        }

        public CyotekCanva()
        {

            this.BackColor = Color.Black;
            this.GridDisplayMode = ImageBoxGridDisplayMode.None;
            this.AutoPan = true;
            this.AllowZoom = true;
            this.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.Zoom = 100;

            this.Resize += CyotekCanva_Resize;

            this.KeyDown += CyotekCanva_KeyDown;
            this.KeyUp += CyotekCanva_KeyUp;


            this.MouseClick += CyotekCanva_MouseClick;

            this.MouseUp += CyotekCanva_MouseUp;


            this.Scroll += CyotekCanva_Scroll;



        }

        private void CyotekCanva_MouseUp(object? sender, MouseEventArgs e)
        {
            this.Cursor = _curCur;
        }

        private void CyotekCanva_Scroll(object? sender, ScrollEventArgs e)
        {
            //throw new NotImplementedException();

            _scrolling = true;
            _scrollCursor = this.Cursor;

            
        }

        private void CyotekCanva_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (UCCanva.Instance.GetColorMode != ENUM.EColorMode.NO_IMG && UCCanva.Instance.GetColorMode != ENUM.EColorMode.NONE)
                {
                    UCCanva.Instance.SetColorModeNone();
                }
            }



            if (e.Button == MouseButtons.Left && UCCanva.Instance.GetColorMode != ENUM.EColorMode.NONE && this.Image != null)
            {
                Point imgPt = this.PointToImage(e.Location);

                if (imgPt.X >= 0 && imgPt.Y >= 0 && imgPt.X < this.Image.Width && imgPt.Y < this.Image.Height)
                {
                    Bitmap bmp = (Bitmap)this.Image;
                    Color picked = bmp.GetPixel(imgPt.X, imgPt.Y);
                    ColorPicked?.Invoke(this, new ColorPickedEventArgs(picked, imgPt));
                }

            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            
        }


        internal void CyotekCanva_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _ctrlKey = false;



        }

        internal void CyotekCanva_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _ctrlKey = true;
                return;
            }

            if (_ctrlKey && e.KeyCode != Keys.V) return;


            if (_ctrlKey && e.KeyCode == Keys.V)
            {
                PasteImage();
            }

        }

        public void PasteClipboard()
        {
            PasteImage();
        }

        private void PasteImage()
        {
            if (Clipboard.ContainsImage())
            {

                Image? image = Clipboard.GetImage();

                if (image != null)
                {
                    this.Image = image;

                    UCCanva.Instance.ImageLoaded = true;
                }
            }
            else
            {
                if (Program.Debug) MessageBox.Show("Clipboard Does Not Contain Image Content");
            }
        }

        private void CyotekCanva_Resize(object? sender, EventArgs e)
        {


        }

        public bool SetColorMode { set { _colorMode = value; } }

        private bool _ctrlKey = false;

        private Cursor _curCur = Cursors.Default;
        private bool _scrolling = false;

        private Cursor _scrollCursor;


        private bool _colorMode = false;

    }
}
