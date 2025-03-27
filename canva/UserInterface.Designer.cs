

namespace canva
{
    partial class UserInterface
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
            panel1 = new Panel();
            _cnva = new CyotekCanva();
            _btnColor1 = new Button();
            _btnColor2 = new Button();
            _btnColor3 = new Button();
            _btnColor4 = new Button();
            _pnlColor1 = new Panel();
            _pnlColor2 = new Panel();
            _pnlColor3 = new Panel();
            _pnlColor4 = new Panel();
            _tbColor1 = new TextBox();
            _tbColor2 = new TextBox();
            _tbColor3 = new TextBox();
            _tbColor4 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(_cnva);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 300);
            panel1.TabIndex = 0;
            // 
            // _cnva
            // 
            _cnva.BackColor = Color.Black;
            _cnva.Dock = DockStyle.Fill;
            _cnva.GridDisplayMode = Cyotek.Windows.Forms.ImageBoxGridDisplayMode.None;
            _cnva.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            _cnva.Location = new Point(0, 0);
            _cnva.Name = "_cnva";
            _cnva.Size = new Size(299, 298);
            _cnva.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Normal;
            _cnva.TabIndex = 0;
            // 
            // _btnColor1
            // 
            _btnColor1.Location = new Point(12, 306);
            _btnColor1.Name = "_btnColor1";
            _btnColor1.Size = new Size(27, 23);
            _btnColor1.TabIndex = 1;
            _btnColor1.UseVisualStyleBackColor = true;
            // 
            // _btnColor2
            // 
            _btnColor2.Location = new Point(12, 335);
            _btnColor2.Name = "_btnColor2";
            _btnColor2.Size = new Size(27, 23);
            _btnColor2.TabIndex = 2;
            _btnColor2.UseVisualStyleBackColor = true;
            // 
            // _btnColor3
            // 
            _btnColor3.Location = new Point(12, 364);
            _btnColor3.Name = "_btnColor3";
            _btnColor3.Size = new Size(27, 23);
            _btnColor3.TabIndex = 3;
            _btnColor3.UseVisualStyleBackColor = true;
            // 
            // _btnColor4
            // 
            _btnColor4.Location = new Point(12, 393);
            _btnColor4.Name = "_btnColor4";
            _btnColor4.Size = new Size(27, 23);
            _btnColor4.TabIndex = 4;
            _btnColor4.UseVisualStyleBackColor = true;
            // 
            // _pnlColor1
            // 
            _pnlColor1.BorderStyle = BorderStyle.FixedSingle;
            _pnlColor1.Location = new Point(45, 306);
            _pnlColor1.Name = "_pnlColor1";
            _pnlColor1.Size = new Size(64, 23);
            _pnlColor1.TabIndex = 5;
            // 
            // _pnlColor2
            // 
            _pnlColor2.BorderStyle = BorderStyle.FixedSingle;
            _pnlColor2.Location = new Point(45, 335);
            _pnlColor2.Name = "_pnlColor2";
            _pnlColor2.Size = new Size(64, 23);
            _pnlColor2.TabIndex = 6;
            // 
            // _pnlColor3
            // 
            _pnlColor3.BorderStyle = BorderStyle.FixedSingle;
            _pnlColor3.Location = new Point(45, 364);
            _pnlColor3.Name = "_pnlColor3";
            _pnlColor3.Size = new Size(64, 23);
            _pnlColor3.TabIndex = 7;
            // 
            // _pnlColor4
            // 
            _pnlColor4.BorderStyle = BorderStyle.FixedSingle;
            _pnlColor4.Location = new Point(45, 393);
            _pnlColor4.Name = "_pnlColor4";
            _pnlColor4.Size = new Size(64, 23);
            _pnlColor4.TabIndex = 8;
            // 
            // _tbColor1
            // 
            _tbColor1.Location = new Point(115, 307);
            _tbColor1.Name = "_tbColor1";
            _tbColor1.ReadOnly = true;
            _tbColor1.Size = new Size(126, 23);
            _tbColor1.TabIndex = 9;
            // 
            // _tbColor2
            // 
            _tbColor2.Location = new Point(115, 336);
            _tbColor2.Name = "_tbColor2";
            _tbColor2.ReadOnly = true;
            _tbColor2.Size = new Size(126, 23);
            _tbColor2.TabIndex = 10;
            // 
            // _tbColor3
            // 
            _tbColor3.Location = new Point(115, 365);
            _tbColor3.Name = "_tbColor3";
            _tbColor3.ReadOnly = true;
            _tbColor3.Size = new Size(126, 23);
            _tbColor3.TabIndex = 11;
            // 
            // _tbColor4
            // 
            _tbColor4.Location = new Point(115, 394);
            _tbColor4.Name = "_tbColor4";
            _tbColor4.ReadOnly = true;
            _tbColor4.Size = new Size(126, 23);
            _tbColor4.TabIndex = 12;
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 428);
            ControlBox = false;
            Controls.Add(_tbColor4);
            Controls.Add(_tbColor3);
            Controls.Add(_tbColor2);
            Controls.Add(_tbColor1);
            Controls.Add(_pnlColor4);
            Controls.Add(_pnlColor3);
            Controls.Add(_pnlColor2);
            Controls.Add(_pnlColor1);
            Controls.Add(_btnColor4);
            Controls.Add(_btnColor3);
            Controls.Add(_btnColor2);
            Controls.Add(_btnColor1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserInterface";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Canva";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private CyotekCanva _cnva;
        private Button _btnColor1;
        private Button _btnColor2;
        private Button _btnColor3;
        private Button _btnColor4;
        private Panel _pnlColor1;
        private Panel _pnlColor2;
        private Panel _pnlColor3;
        private Panel _pnlColor4;
        private TextBox _tbColor1;
        private TextBox _tbColor2;
        private TextBox _tbColor3;
        private TextBox _tbColor4;
    }
}
