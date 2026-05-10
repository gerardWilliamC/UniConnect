namespace UniConnect
{
    partial class frmAdminLogin
    {
        private System.ComponentModel.IContainer components = null;

        // Left brand panel
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblOfficial;
        private System.Windows.Forms.Label lblPortalTitle;
        private System.Windows.Forms.Label lblPortalDesc;
        private System.Windows.Forms.Label lblBadge;

        // Right form panel
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblAdminId;
        private System.Windows.Forms.TextBox txtAdminId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.Button btnBackToStudent;
        private System.Windows.Forms.Label lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblOfficial = new System.Windows.Forms.Label();
            this.lblPortalTitle = new System.Windows.Forms.Label();
            this.lblPortalDesc = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblAdminId = new System.Windows.Forms.Label();
            this.txtAdminId = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.btnBackToStudent = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.pnlLeft.Controls.Add(this.pbLogo);
            this.pnlLeft.Controls.Add(this.lblBrand);
            this.pnlLeft.Controls.Add(this.lblOfficial);
            this.pnlLeft.Controls.Add(this.lblPortalTitle);
            this.pnlLeft.Controls.Add(this.lblPortalDesc);
            this.pnlLeft.Controls.Add(this.lblBadge);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(400, 650);
            this.pnlLeft.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Location = new System.Drawing.Point(130, 130);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(140, 140);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(0, 285);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(400, 35);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "UniConnect";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOfficial
            // 
            this.lblOfficial.BackColor = System.Drawing.Color.Transparent;
            this.lblOfficial.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblOfficial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblOfficial.Location = new System.Drawing.Point(0, 322);
            this.lblOfficial.Name = "lblOfficial";
            this.lblOfficial.Size = new System.Drawing.Size(400, 18);
            this.lblOfficial.TabIndex = 2;
            this.lblOfficial.Text = "OFFICIAL";
            this.lblOfficial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortalTitle
            // 
            this.lblPortalTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPortalTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPortalTitle.ForeColor = System.Drawing.Color.White;
            this.lblPortalTitle.Location = new System.Drawing.Point(0, 380);
            this.lblPortalTitle.Name = "lblPortalTitle";
            this.lblPortalTitle.Size = new System.Drawing.Size(400, 28);
            this.lblPortalTitle.TabIndex = 3;
            this.lblPortalTitle.Text = "Admin Portal";
            this.lblPortalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortalDesc
            // 
            this.lblPortalDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblPortalDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPortalDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblPortalDesc.Location = new System.Drawing.Point(0, 410);
            this.lblPortalDesc.Name = "lblPortalDesc";
            this.lblPortalDesc.Size = new System.Drawing.Size(400, 40);
            this.lblPortalDesc.TabIndex = 4;
            this.lblPortalDesc.Text = "Restricted access for authorized\r\nstaff and administrators only.";
            this.lblPortalDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBadge
            // 
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.White;
            this.lblBadge.Location = new System.Drawing.Point(110, 475);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(180, 28);
            this.lblBadge.TabIndex = 5;
            this.lblBadge.Text = "Administrator / Staff Only";
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblWelcome);
            this.pnlRight.Controls.Add(this.lblWelcomeSub);
            this.pnlRight.Controls.Add(this.pnlWarning);
            this.pnlRight.Controls.Add(this.lblAdminId);
            this.pnlRight.Controls.Add(this.txtAdminId);
            this.pnlRight.Controls.Add(this.lblPassword);
            this.pnlRight.Controls.Add(this.lnkForgotPassword);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.btnAdminLogin);
            this.pnlRight.Controls.Add(this.btnBackToStudent);
            this.pnlRight.Controls.Add(this.lblFooter);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(400, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(600, 650);
            this.pnlRight.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblWelcome.Location = new System.Drawing.Point(80, 60);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(440, 40);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Admin Sign In";
            // 
            // lblWelcomeSub
            // 
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblWelcomeSub.Location = new System.Drawing.Point(80, 102);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Size = new System.Drawing.Size(440, 22);
            this.lblWelcomeSub.TabIndex = 1;
            this.lblWelcomeSub.Text = "Authorized personnel only";
            // 
            // pnlWarning (warning banner)
            // 
            this.pnlWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.pnlWarning.Controls.Add(this.lblWarning);
            this.pnlWarning.Location = new System.Drawing.Point(80, 145);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(440, 50);
            this.pnlWarning.TabIndex = 2;
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.lblWarning.Location = new System.Drawing.Point(15, 8);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(410, 35);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "⚠  This portal is for staff and admins only. All activity is logged.";
            // 
            // lblAdminId
            // 
            this.lblAdminId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdminId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblAdminId.Location = new System.Drawing.Point(80, 215);
            this.lblAdminId.Name = "lblAdminId";
            this.lblAdminId.Size = new System.Drawing.Size(440, 18);
            this.lblAdminId.TabIndex = 3;
            this.lblAdminId.Text = "Admin ID / Email";
            // 
            // txtAdminId
            // 
            this.txtAdminId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdminId.Location = new System.Drawing.Point(80, 237);
            this.txtAdminId.Name = "txtAdminId";
            this.txtAdminId.Size = new System.Drawing.Size(440, 25);
            this.txtAdminId.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblPassword.Location = new System.Drawing.Point(80, 285);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(220, 18);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lnkForgotPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.lnkForgotPassword.Location = new System.Drawing.Point(380, 285);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(140, 18);
            this.lnkForgotPassword.TabIndex = 6;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Forgot password?";
            this.lnkForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(80, 307);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(440, 25);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnAdminLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdminLogin.FlatAppearance.BorderSize = 0;
            this.btnAdminLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdminLogin.ForeColor = System.Drawing.Color.White;
            this.btnAdminLogin.Location = new System.Drawing.Point(80, 365);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(440, 42);
            this.btnAdminLogin.TabIndex = 8;
            this.btnAdminLogin.Text = "Sign in as Admin";
            this.btnAdminLogin.UseVisualStyleBackColor = false;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // btnBackToStudent
            // 
            this.btnBackToStudent.BackColor = System.Drawing.Color.White;
            this.btnBackToStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToStudent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.btnBackToStudent.FlatAppearance.BorderSize = 1;
            this.btnBackToStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToStudent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackToStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.btnBackToStudent.Location = new System.Drawing.Point(80, 425);
            this.btnBackToStudent.Name = "btnBackToStudent";
            this.btnBackToStudent.Size = new System.Drawing.Size(440, 42);
            this.btnBackToStudent.TabIndex = 9;
            this.btnBackToStudent.Text = "←   Back to Student Login";
            this.btnBackToStudent.UseVisualStyleBackColor = false;
            this.btnBackToStudent.Click += new System.EventHandler(this.btnBackToStudent_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblFooter.Location = new System.Drawing.Point(80, 525);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(440, 18);
            this.lblFooter.TabIndex = 10;
            this.lblFooter.Text = "UniConnect Portal   •   LPU 2025-2026";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniConnect — Admin Sign In";
            this.Load += new System.EventHandler(this.frmAdminLogin_Load);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}