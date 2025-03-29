namespace canva.UI_ELEMENTS
{
    partial class UserInterfaceVert
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
            _pnlCtrls.SuspendLayout();
            _pnlBtns.SuspendLayout();
            SuspendLayout();
            // 
            // _ucCnva
            // 
            _ucCnva.Size = new Size(300, 300);
            // 
            // _ucCmd
            // 
            _ucCmd.Dock = DockStyle.Bottom;
            _ucCmd.Location = new Point(0, 300);
            _ucCmd.Size = new Size(300, 173);
            // 
            // _pnlCtrls
            // 
            _pnlCtrls.Dock = DockStyle.Top;
            _pnlCtrls.Location = new Point(0, 0);
            _pnlCtrls.Size = new Size(300, 473);
            // 
            // _pnlBtns
            // 
            _pnlBtns.Dock = DockStyle.Fill;
            _pnlBtns.Location = new Point(0, 473);
            _pnlBtns.Size = new Size(300, 80);
            // 
            // _btnClose
            // 
            _btnClose.Dock = DockStyle.Fill;
            _btnClose.Location = new Point(0, 40);
            _btnClose.Size = new Size(300, 40);
            // 
            // _btnPaste
            // 
            _btnPaste.Dock = DockStyle.Top;
            _btnPaste.Location = new Point(0, 0);
            _btnPaste.Size = new Size(300, 40);
            // 
            // UserInterfaceVert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 553);
            Name = "UserInterfaceVert";
            _pnlCtrls.ResumeLayout(false);
            _pnlBtns.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}