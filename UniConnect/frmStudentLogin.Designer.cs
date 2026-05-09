using System.Drawing;
using System.Windows.Forms;

namespace UniConnect
{
    partial class frmStudentLogin
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLeft;
        private PictureBox pbLogo;
        private Label lblBrand;
        private Label lblOfficial;
        private Label lblPortalTitle;
        private Label lblPortalDesc;
        private Label lblBadge;

        private Panel pnlRight;
        private Label lblWelcome;
        private Label lblWelcomeSub;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private LinkLabel lnkForgotPassword;
        private TextBox txtPassword;
        private Button btnStudentLogin;
        private Button btnAdminLogin;
        private Label lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblOfficial = new System.Windows.Forms.Label();
            this.lblPortalTitle = new System.Windows.Forms.Label();
            this.lblPortalDesc = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnStudentLogin = new System.Windows.Forms.Button();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(21)))), ((int)(((byte)(56)))));
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
            this.lblPortalTitle.Text = "Student Portal";
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
            this.lblPortalDesc.Text = "Access your grades, schedule,\r\nand announcements anytime.";
            this.lblPortalDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBadge
            // 
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(15)))), ((int)(((byte)(42)))));
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.White;
            this.lblBadge.Location = new System.Drawing.Point(110, 475);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(180, 28);
            this.lblBadge.TabIndex = 5;
            this.lblBadge.Text = "Student Access Portal";
            this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblWelcome);
            this.pnlRight.Controls.Add(this.lblWelcomeSub);
            this.pnlRight.Controls.Add(this.lblEmail);
            this.pnlRight.Controls.Add(this.txtEmail);
            this.pnlRight.Controls.Add(this.lblPassword);
            this.pnlRight.Controls.Add(this.lnkForgotPassword);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.btnStudentLogin);
            this.pnlRight.Controls.Add(this.btnAdminLogin);
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
            this.lblWelcome.Location = new System.Drawing.Point(80, 100);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(440, 40);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back";
            // 
            // lblWelcomeSub
            // 
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblWelcomeSub.Location = new System.Drawing.Point(80, 142);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Size = new System.Drawing.Size(440, 22);
            this.lblWelcomeSub.TabIndex = 1;
            this.lblWelcomeSub.Text = "Sign in to your student account";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblEmail.Location = new System.Drawing.Point(80, 200);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(440, 18);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Student Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(80, 222);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(440, 25);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblPassword.Location = new System.Drawing.Point(80, 270);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(220, 18);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(15)))), ((int)(((byte)(42)))));
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lnkForgotPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(21)))), ((int)(((byte)(56)))));
            this.lnkForgotPassword.Location = new System.Drawing.Point(380, 270);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(140, 18);
            this.lnkForgotPassword.TabIndex = 5;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Forgot password?";
            this.lnkForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(80, 292);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(440, 25);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnStudentLogin
            // 
            this.btnStudentLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnStudentLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudentLogin.FlatAppearance.BorderSize = 0;
            this.btnStudentLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStudentLogin.ForeColor = System.Drawing.Color.White;
            this.btnStudentLogin.Location = new System.Drawing.Point(80, 350);
            this.btnStudentLogin.Name = "btnStudentLogin";
            this.btnStudentLogin.Size = new System.Drawing.Size(440, 42);
            this.btnStudentLogin.TabIndex = 7;
            this.btnStudentLogin.Text = "Sign in as Student";
            this.btnStudentLogin.UseVisualStyleBackColor = false;
            this.btnStudentLogin.Click += new System.EventHandler(this.btnStudentLogin_Click);

            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblFooter.Location = new System.Drawing.Point(80, 510);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(440, 18);
            this.lblFooter.TabIndex = 9;
            this.lblFooter.Text = "UniConnect Portal   •   LPU 2025-2026";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = global::UniConnect.Properties.Resources.L2___Dark_Mode;
            this.pbLogo.InitialImage = global::UniConnect.Properties.Resources.L2___Dark_Mode;
            this.pbLogo.Location = new System.Drawing.Point(81, 78);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(232, 204);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // frmStudentLogin
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
            this.Name = "frmStudentLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniConnect — Student Login";
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}