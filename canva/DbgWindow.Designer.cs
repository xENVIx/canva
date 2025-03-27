namespace canva
{
    partial class DbgWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // _rtbLog
            // 
            _rtbLog.Dock = DockStyle.Fill;
            _rtbLog.Location = new Point(0, 0);
            _rtbLog.Name = "_rtbLog";
            _rtbLog.Size = new Size(1106, 595);
            _rtbLog.TabIndex = 0;
            _rtbLog.Text = "";
            _rtbLog.WordWrap = false;
            // 
            // DbgWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 595);
            ControlBox = false;
            Controls.Add(_rtbLog);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DbgWindow";
            Text = "DbgWindow";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox _rtbLog;
    }
}