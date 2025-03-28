using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cyotek.Windows.Forms;


using canva.Classes;

namespace canva.UI_ELEMENTS
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
            Cursor = _curCur;


            CursorChanged += CyotekCanva_CursorChanged;

        }

        private void CyotekCanva_CursorChanged(object? sender, EventArgs e)
        {

            if (_scrolling && Cursor == _scrollCursor) return;

            if (Cursor != _curCur) Cursor = _curCur;
        }

        public CyotekCanva()
        {

            BackColor = Color.Black;
            GridDisplayMode = ImageBoxGridDisplayMode.None;
            AutoPan = true;
            AllowZoom = true;
            InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            Zoom = 100;

            Resize += CyotekCanva_Resize;

            KeyDown += CyotekCanva_KeyDown;
            KeyUp += CyotekCanva_KeyUp;


            MouseClick += CyotekCanva_MouseClick;

            MouseUp += CyotekCanva_MouseUp;


            Scroll += CyotekCanva_Scroll;



        }

        private void CyotekCanva_MouseUp(object? sender, MouseEventArgs e)
        {
            Cursor = _curCur;
        }

        private void CyotekCanva_Scroll(object? sender, ScrollEventArgs e)
        {
            //throw new NotImplementedException();

            _scrolling = true;
            _scrollCursor = Cursor;


        }

        private void CyotekCanva_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Classes.ColorMode.Instance.GetColorMode != ENUM.EColorMode.NO_IMG && Classes.ColorMode.Instance.GetColorMode != ENUM.EColorMode.NONE)
                {
                    Classes.ColorMode.Instance.SetColorModeNone();
                }
            }



            if (e.Button == MouseButtons.Left && Classes.ColorMode.Instance.GetColorMode != ENUM.EColorMode.NONE && Image != null)
            {
                Point imgPt = PointToImage(e.Location);

                if (imgPt.X >= 0 && imgPt.Y >= 0 && imgPt.X < Image.Width && imgPt.Y < Image.Height)
                {
                    Bitmap bmp = (Bitmap)Image;
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
                PasteClipboard();
            }

        }


        public void PasteClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                Image? img = Clipboard.GetImage();

                if (img == null) return;

                PasteImage(img);
            }
        }


        public void PasteImage(Image img)
        {
            
            Image = img;

            UserInterface.Instance.ImageLoaded = true;

                
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
