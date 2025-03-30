namespace canva.UI_ELEMENTS
{
    partial class UCCanva
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _cnva = new CyotekCanva();
            _btnBack = new CvButton();
            _btnForward = new CvButton();
            SuspendLayout();
            // 
            // _cnva
            // 
            _cnva.BackColor = Color.Black;
            _cnva.Dock = DockStyle.Top;
            _cnva.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
            _cnva.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            _cnva.Location = new Point(0, 0);
            _cnva.Name = "_cnva";
            _cnva.Size = new Size(300, 300);
            _cnva.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Normal;
            _cnva.TabIndex = 0;
            // 
            // _btnBack
            // 
            _btnBack.BackColor = Color.FromArgb(220, 255, 255);
            _btnBack.Dock = DockStyle.Left;
            _btnBack.FlatAppearance.BorderColor = Color.FromArgb(220, 255, 255);
            _btnBack.FlatAppearance.MouseDownBackColor = Color.HotPink;
            _btnBack.FlatAppearance.MouseOverBackColor = Color.Cyan;
            _btnBack.FlatStyle = FlatStyle.Flat;
            _btnBack.ForeColor = Color.FromArgb(0, 0, 0);
            _btnBack.Location = new Point(0, 300);
            _btnBack.Name = "_btnBack";
            _btnBack.Size = new Size(75, 28);
            _btnBack.TabIndex = 1;
            _btnBack.Text = "<--";
            _btnBack.UseVisualStyleBackColor = false;
            _btnBack.Click += _btnBack_Click;
            // 
            // _btnForward
            // 
            _btnForward.BackColor = Color.FromArgb(220, 255, 255);
            _btnForward.Dock = DockStyle.Fill;
            _btnForward.FlatAppearance.BorderColor = Color.FromArgb(220, 255, 255);
            _btnForward.FlatAppearance.MouseDownBackColor = Color.HotPink;
            _btnForward.FlatAppearance.MouseOverBackColor = Color.Cyan;
            _btnForward.FlatStyle = FlatStyle.Flat;
            _btnForward.ForeColor = Color.FromArgb(0, 0, 0);
            _btnForward.Location = new Point(75, 300);
            _btnForward.Name = "_btnForward";
            _btnForward.Size = new Size(225, 28);
            _btnForward.TabIndex = 2;
            _btnForward.Text = "-->";
            _btnForward.UseVisualStyleBackColor = false;
            _btnForward.Click += _btnForward_Click;
            // 
            // UCCanva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(_btnForward);
            Controls.Add(_btnBack);
            Controls.Add(_cnva);
            Name = "UCCanva";
            Size = new Size(300, 328);
            ResumeLayout(false);
        }

        #endregion

        private CyotekCanva _cnva;
        private CvButton _btnBack;
        private CvButton _btnForward;
    }
}
