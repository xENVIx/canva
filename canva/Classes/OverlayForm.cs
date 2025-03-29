using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
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
