﻿namespace canva.UI_ELEMENTS
{
    partial class UserInterfaceHoriz
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
            _ucCnva.Size = new Size(300, 328);
            // 
            // _ucCmd
            // 
            _ucCmd.Location = new Point(300, 0);
            _ucCmd.Size = new Size(257, 328);
            // 
            // _pnlCtrls
            // 
            _pnlCtrls.Dock = DockStyle.Top;
            _pnlCtrls.Location = new Point(0, 0);
            _pnlCtrls.Size = new Size(557, 328);
            // 
            // _pnlBtns
            // 
            _pnlBtns.Dock = DockStyle.Fill;
            _pnlBtns.Location = new Point(0, 328);
            _pnlBtns.Size = new Size(557, 49);
            // 
            // _btnClose
            // 
            _btnClose.Dock = DockStyle.Fill;
            _btnClose.FlatAppearance.BorderColor = Color.FromArgb(220, 255, 255);
            _btnClose.FlatAppearance.MouseDownBackColor = Color.HotPink;
            _btnClose.FlatAppearance.MouseOverBackColor = Color.Cyan;
            _btnClose.Location = new Point(300, 0);
            _btnClose.Size = new Size(257, 49);
            // 
            // _btnPaste
            // 
            _btnPaste.Dock = DockStyle.Left;
            _btnPaste.FlatAppearance.BorderColor = Color.FromArgb(220, 255, 255);
            _btnPaste.FlatAppearance.MouseDownBackColor = Color.HotPink;
            _btnPaste.FlatAppearance.MouseOverBackColor = Color.Cyan;
            _btnPaste.Location = new Point(0, 0);
            _btnPaste.Size = new Size(300, 49);
            // 
            // UserInterfaceHoriz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 377);
            Name = "UserInterfaceHoriz";
            _pnlCtrls.ResumeLayout(false);
            _pnlBtns.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}