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
            SuspendLayout();
            // 
            // _cnva
            // 
            _cnva.BackColor = Color.Black;
            _cnva.Dock = DockStyle.Fill;
            _cnva.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
            _cnva.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            _cnva.Location = new Point(0, 0);
            _cnva.Name = "_cnva";
            _cnva.Size = new Size(301, 300);
            _cnva.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Normal;
            _cnva.TabIndex = 0;
            // 
            // UCCanva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(_cnva);
            Name = "UCCanva";
            Size = new Size(301, 300);
            ResumeLayout(false);
        }

        #endregion

        private CyotekCanva _cnva;
    }
}
