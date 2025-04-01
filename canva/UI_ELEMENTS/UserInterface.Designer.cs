namespace canva.UI_ELEMENTS
{
    partial class UserInterface
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
            components = new System.ComponentModel.Container();
            _ucCnva = new UCCanva();
            _ucCmd = new UCCommand();
            _pnlCtrls = new Panel();
            _pnlBtns = new Panel();
            _btnClose = new CvButton();
            _btnPaste = new CvButton();
            _cmsOptions = new ContextMenuStrip(components);
            _pnlCtrls.SuspendLayout();
            _pnlBtns.SuspendLayout();
            SuspendLayout();
            // 
            // _ucCnva
            // 
            _ucCnva.BackColor = Color.FromArgb(220, 255, 255);
            _ucCnva.Dock = DockStyle.Fill;
            _ucCnva.Location = new Point(0, 0);
            _ucCnva.Name = "_ucCnva";
            _ucCnva.Size = new Size(0, 277);
            _ucCnva.TabIndex = 0;
            // 
            // _ucCmd
            // 
            _ucCmd.BackColor = Color.FromArgb(220, 255, 255);
            _ucCmd.Dock = DockStyle.Right;
            _ucCmd.Location = new Point(-103, 0);
            _ucCmd.Name = "_ucCmd";
            _ucCmd.Size = new Size(388, 277);
            _ucCmd.TabIndex = 1;
            // 
            // _pnlCtrls
            // 
            _pnlCtrls.Controls.Add(_ucCnva);
            _pnlCtrls.Controls.Add(_ucCmd);
            _pnlCtrls.Location = new Point(339, 40);
            _pnlCtrls.Name = "_pnlCtrls";
            _pnlCtrls.Size = new Size(285, 277);
            _pnlCtrls.TabIndex = 4;
            // 
            // _pnlBtns
            // 
            _pnlBtns.Controls.Add(_btnClose);
            _pnlBtns.Controls.Add(_btnPaste);
            _pnlBtns.Location = new Point(100, 54);
            _pnlBtns.Name = "_pnlBtns";
            _pnlBtns.Size = new Size(200, 100);
            _pnlBtns.TabIndex = 5;
            // 
            // _btnClose
            // 
            _btnClose.BackColor = Color.FromArgb(220, 255, 255);
            _btnClose.FlatAppearance.BorderColor = Color.FromArgb(220, 255, 255);
            _btnClose.FlatAppearance.MouseDownBackColor = Color.HotPink;
            _btnClose.FlatAppearance.MouseOverBackColor = Color.Cyan;
            _btnClose.FlatStyle = FlatStyle.Flat;
            _btnClose.ForeColor = Color.FromArgb(0, 0, 0);
            _btnClose.Location = new Point(88, 65);
            _btnClose.Name = "_btnClose";
            _btnClose.Size = new Size(96, 23);
            _btnClose.TabIndex = 1;
            _btnClose.Text = "Close App";
            _btnClose.UseVisualStyleBackColor = false;
            // 
            // _btnPaste
            // 
            _btnPaste.BackColor = Color.FromArgb(220, 255, 255);
            _btnPaste.FlatAppearance.BorderColor = Color.FromArgb(220, 255, 255);
            _btnPaste.FlatAppearance.MouseDownBackColor = Color.HotPink;
            _btnPaste.FlatAppearance.MouseOverBackColor = Color.Cyan;
            _btnPaste.FlatStyle = FlatStyle.Flat;
            _btnPaste.ForeColor = Color.FromArgb(0, 0, 0);
            _btnPaste.Location = new Point(12, 26);
            _btnPaste.Name = "_btnPaste";
            _btnPaste.Size = new Size(96, 23);
            _btnPaste.TabIndex = 0;
            _btnPaste.Text = "Paste Image";
            _btnPaste.UseVisualStyleBackColor = false;
            // 
            // _cmsOptions
            // 
            _cmsOptions.Name = "contextMenuStrip1";
            _cmsOptions.Size = new Size(61, 4);
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 361);
            ControlBox = false;
            Controls.Add(_pnlBtns);
            Controls.Add(_pnlCtrls);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserInterface";
            StartPosition = FormStartPosition.Manual;
            Text = "FrmMain";
            _pnlCtrls.ResumeLayout(false);
            _pnlBtns.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion


        protected UCCanva _ucCnva;
        protected UCCommand _ucCmd;
        protected Panel _pnlCtrls;
        protected Panel _pnlBtns;
        protected UI_ELEMENTS.CvButton _btnClose;
        protected UI_ELEMENTS.CvButton _btnPaste;
        private ContextMenuStrip _cmsOptions;
    }
}