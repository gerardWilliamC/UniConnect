namespace UniConnect
{
    partial class frmPostAnnouncement
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox pbSidebarLogo;
        private System.Windows.Forms.Label lblSidebarBrand;
        private System.Windows.Forms.Label lblSidebarSub;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavStudents;
        private System.Windows.Forms.Button btnNavEncodeGrades;
        private System.Windows.Forms.Button btnNavEnrollments;
        private System.Windows.Forms.Button btnNavPostAnnouncement;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavAuditLogs;
        private System.Windows.Forms.Panel pnlSidebarUser;
        private System.Windows.Forms.PictureBox pbUserAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserId;

        // Main content
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblAdminPill;

        // Search row
        private System.Windows.Forms.Panel pnlSearchRow;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

        // New announcement form (left)
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblTitleField;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblAudienceField;
        private System.Windows.Forms.ComboBox cmbAudience;
        private System.Windows.Forms.Label lblContentField;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnCancel;

        // Posted announcements (right)
        private System.Windows.Forms.Panel pnlPosted;
        private System.Windows.Forms.Label lblPostedTitle;
        private System.Windows.Forms.Panel pnlPostedList;

        // Watermark
        private System.Windows.Forms.PictureBox pbWatermark;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pbSidebarLogo = new System.Windows.Forms.PictureBox();
            this.lblSidebarBrand = new System.Windows.Forms.Label();
            this.lblSidebarSub = new System.Windows.Forms.Label();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavStudents = new System.Windows.Forms.Button();
            this.btnNavEncodeGrades = new System.Windows.Forms.Button();
            this.btnNavEnrollments = new System.Windows.Forms.Button();
            this.btnNavPostAnnouncement = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavAuditLogs = new System.Windows.Forms.Button();
            this.pnlSidebarUser = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(155, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(30, 40);
            this.btnLogout.Text = "➔";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.pbUserAvatar = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblAdminPill = new System.Windows.Forms.Label();
            this.pnlSearchRow = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblTitleField = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAudienceField = new System.Windows.Forms.Label();
            this.cmbAudience = new System.Windows.Forms.ComboBox();
            this.lblContentField = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlPosted = new System.Windows.Forms.Panel();
            this.lblPostedTitle = new System.Windows.Forms.Label();
            this.pnlPostedList = new System.Windows.Forms.Panel();
            this.pbWatermark = new System.Windows.Forms.PictureBox();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).BeginInit();
            this.pnlSidebarUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlSearchRow.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlPosted.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermark)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.pnlSidebar.Controls.Add(this.pbSidebarLogo);
            this.pnlSidebar.Controls.Add(this.lblSidebarBrand);
            this.pnlSidebar.Controls.Add(this.lblSidebarSub);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.btnNavStudents);
            this.pnlSidebar.Controls.Add(this.btnNavEncodeGrades);
            this.pnlSidebar.Controls.Add(this.btnNavEnrollments);
            this.pnlSidebar.Controls.Add(this.btnNavPostAnnouncement);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Controls.Add(this.btnNavAuditLogs);
            this.pnlSidebar.Controls.Add(this.pnlSidebarUser);
            this.pnlSidebarUser.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 720);
            this.pnlSidebar.TabIndex = 0;
            // sidebar dividers
            System.Windows.Forms.Panel pnlSidebarHeaderLine = new System.Windows.Forms.Panel();
            pnlSidebarHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            pnlSidebarHeaderLine.Location = new System.Drawing.Point(15, 80);
            pnlSidebarHeaderLine.Size = new System.Drawing.Size(190, 1);
            pnlSidebarHeaderLine.Name = "pnlSidebarHeaderLine";
            this.pnlSidebar.Controls.Add(pnlSidebarHeaderLine);
            System.Windows.Forms.Panel pnlSidebarFooterLine = new System.Windows.Forms.Panel();
            pnlSidebarFooterLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            pnlSidebarFooterLine.Location = new System.Drawing.Point(15, 625);
            pnlSidebarFooterLine.Size = new System.Drawing.Size(190, 1);
            pnlSidebarFooterLine.Name = "pnlSidebarFooterLine";
            this.pnlSidebar.Controls.Add(pnlSidebarFooterLine);
            // 
            // pbSidebarLogo
            // 
            this.pbSidebarLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbSidebarLogo.Location = new System.Drawing.Point(20, 20);
            this.pbSidebarLogo.Name = "pbSidebarLogo";
            this.pbSidebarLogo.Size = new System.Drawing.Size(40, 40);
            this.pbSidebarLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSidebarLogo.TabIndex = 0;
            this.pbSidebarLogo.TabStop = false;
            // 
            // lblSidebarBrand
            // 
            this.lblSidebarBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblSidebarBrand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSidebarBrand.ForeColor = System.Drawing.Color.White;
            this.lblSidebarBrand.Location = new System.Drawing.Point(70, 20);
            this.lblSidebarBrand.Name = "lblSidebarBrand";
            this.lblSidebarBrand.Size = new System.Drawing.Size(140, 22);
            this.lblSidebarBrand.TabIndex = 1;
            this.lblSidebarBrand.Text = "UniConnect";
            // 
            // lblSidebarSub
            // 
            this.lblSidebarSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSidebarSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSidebarSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblSidebarSub.Location = new System.Drawing.Point(70, 42);
            this.lblSidebarSub.Name = "lblSidebarSub";
            this.lblSidebarSub.Size = new System.Drawing.Size(140, 16);
            this.lblSidebarSub.TabIndex = 2;
            this.lblSidebarSub.Text = "Admin Portal";
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(15, 100);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(190, 38);
            this.btnNavDashboard.TabIndex = 3;
            this.btnNavDashboard.Text = "  Dashboard";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // btnNavStudents
            // 
            this.btnNavStudents.BackColor = System.Drawing.Color.Transparent;
            this.btnNavStudents.FlatAppearance.BorderSize = 0;
            this.btnNavStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStudents.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavStudents.ForeColor = System.Drawing.Color.White;
            this.btnNavStudents.Location = new System.Drawing.Point(15, 145);
            this.btnNavStudents.Name = "btnNavStudents";
            this.btnNavStudents.Size = new System.Drawing.Size(190, 38);
            this.btnNavStudents.TabIndex = 4;
            this.btnNavStudents.Text = "  Manage Students";
            this.btnNavStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStudents.UseVisualStyleBackColor = false;
            this.btnNavStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStudents.Click += new System.EventHandler(this.btnNavStudents_Click);
            // 
            // btnNavEncodeGrades
            // 
            this.btnNavEncodeGrades.BackColor = System.Drawing.Color.Transparent;
            this.btnNavEncodeGrades.FlatAppearance.BorderSize = 0;
            this.btnNavEncodeGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavEncodeGrades.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavEncodeGrades.ForeColor = System.Drawing.Color.White;
            this.btnNavEncodeGrades.Location = new System.Drawing.Point(15, 190);
            this.btnNavEncodeGrades.Name = "btnNavEncodeGrades";
            this.btnNavEncodeGrades.Size = new System.Drawing.Size(190, 38);
            this.btnNavEncodeGrades.TabIndex = 5;
            this.btnNavEncodeGrades.Text = "  Encode Grades";
            this.btnNavEncodeGrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavEncodeGrades.UseVisualStyleBackColor = false;
            this.btnNavEncodeGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavEncodeGrades.Click += new System.EventHandler(this.btnNavEncodeGrades_Click);
            // 
            // btnNavEnrollments
            // 
            this.btnNavEnrollments.BackColor = System.Drawing.Color.Transparent;
            this.btnNavEnrollments.FlatAppearance.BorderSize = 0;
            this.btnNavEnrollments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavEnrollments.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavEnrollments.ForeColor = System.Drawing.Color.White;
            this.btnNavEnrollments.Location = new System.Drawing.Point(15, 235);
            this.btnNavEnrollments.Name = "btnNavEnrollments";
            this.btnNavEnrollments.Size = new System.Drawing.Size(190, 38);
            this.btnNavEnrollments.TabIndex = 6;
            this.btnNavEnrollments.Text = "  Manage Enrollments";
            this.btnNavEnrollments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavEnrollments.UseVisualStyleBackColor = false;
            this.btnNavEnrollments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavEnrollments.Click += new System.EventHandler(this.btnNavEnrollments_Click);
            // 
            // btnNavPostAnnouncement (ACTIVE)
            // 
            this.btnNavPostAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.btnNavPostAnnouncement.FlatAppearance.BorderSize = 0;
            this.btnNavPostAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPostAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavPostAnnouncement.ForeColor = System.Drawing.Color.White;
            this.btnNavPostAnnouncement.Location = new System.Drawing.Point(15, 280);
            this.btnNavPostAnnouncement.Name = "btnNavPostAnnouncement";
            this.btnNavPostAnnouncement.Size = new System.Drawing.Size(190, 38);
            this.btnNavPostAnnouncement.TabIndex = 7;
            this.btnNavPostAnnouncement.Text = "  Post Announcement";
            this.btnNavPostAnnouncement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPostAnnouncement.UseVisualStyleBackColor = false;
            this.btnNavPostAnnouncement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavPostAnnouncement.Click += new System.EventHandler(this.btnNavPostAnnouncement_Click);
            // 
            // btnNavReports
            // 
            this.btnNavReports.BackColor = System.Drawing.Color.Transparent;
            this.btnNavReports.FlatAppearance.BorderSize = 0;
            this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReports.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavReports.ForeColor = System.Drawing.Color.White;
            this.btnNavReports.Location = new System.Drawing.Point(15, 325);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Size = new System.Drawing.Size(190, 38);
            this.btnNavReports.TabIndex = 8;
            this.btnNavReports.Text = "  Generate Reports";
            this.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavReports.UseVisualStyleBackColor = false;
            this.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavReports.Click += new System.EventHandler(this.btnNavReports_Click);
            // 
            // btnNavAuditLogs
            // 
            this.btnNavAuditLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnNavAuditLogs.FlatAppearance.BorderSize = 0;
            this.btnNavAuditLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAuditLogs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavAuditLogs.ForeColor = System.Drawing.Color.White;
            this.btnNavAuditLogs.Location = new System.Drawing.Point(15, 370);
            this.btnNavAuditLogs.Name = "btnNavAuditLogs";
            this.btnNavAuditLogs.Size = new System.Drawing.Size(190, 38);
            this.btnNavAuditLogs.TabIndex = 9;
            this.btnNavAuditLogs.Text = "  Audit Logs";
            this.btnNavAuditLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAuditLogs.UseVisualStyleBackColor = false;
            this.btnNavAuditLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAuditLogs.Click += new System.EventHandler(this.btnNavAuditLogs_Click);
            // 
            // pnlSidebarUser
            // 
            this.pnlSidebarUser.BackColor = System.Drawing.Color.Transparent;
            this.pnlSidebarUser.Controls.Add(this.pbUserAvatar);
            this.pnlSidebarUser.Controls.Add(this.lblUserName);
            this.pnlSidebarUser.Controls.Add(this.lblUserId);
            this.pnlSidebarUser.Location = new System.Drawing.Point(15, 640);
            this.pnlSidebarUser.Name = "pnlSidebarUser";
            this.pnlSidebarUser.Size = new System.Drawing.Size(190, 60);
            this.pnlSidebarUser.TabIndex = 10;
            // 
            // pbUserAvatar
            // 
            this.pbUserAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.pbUserAvatar.Location = new System.Drawing.Point(0, 10);
            this.pbUserAvatar.Name = "pbUserAvatar";
            this.pbUserAvatar.Size = new System.Drawing.Size(40, 40);
            this.pbUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserAvatar.TabIndex = 0;
            this.pbUserAvatar.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(50, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(140, 18);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Administrator";
            // 
            // lblUserId
            // 
            this.lblUserId.BackColor = System.Drawing.Color.Transparent;
            this.lblUserId.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUserId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblUserId.Location = new System.Drawing.Point(50, 32);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(140, 16);
            this.lblUserId.TabIndex = 2;
            this.lblUserId.Text = "ICT Admin";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pnlMain.Controls.Add(this.pnlTopBar);
            this.pnlMain.Controls.Add(this.pnlSearchRow);
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Controls.Add(this.pnlPosted);
            this.pnlMain.Controls.Add(this.pbWatermark);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(220, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(960, 720);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Controls.Add(this.lblAdminPill);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(960, 70);
            this.pnlTopBar.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblPageTitle.Location = new System.Drawing.Point(30, 20);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(300, 32);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Post Announcement";
            // 
            // lblAdminPill
            // 
            this.lblAdminPill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.lblAdminPill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdminPill.ForeColor = System.Drawing.Color.White;
            this.lblAdminPill.Location = new System.Drawing.Point(770, 22);
            this.lblAdminPill.Name = "lblAdminPill";
            this.lblAdminPill.Size = new System.Drawing.Size(160, 28);
            this.lblAdminPill.TabIndex = 1;
            this.lblAdminPill.Text = "Administrator Access";
            this.lblAdminPill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSearchRow
            // 
            this.pnlSearchRow.BackColor = System.Drawing.Color.White;
            this.pnlSearchRow.Controls.Add(this.txtSearch);
            this.pnlSearchRow.Controls.Add(this.btnSearch);
            this.pnlSearchRow.Location = new System.Drawing.Point(30, 90);
            this.pnlSearchRow.Name = "pnlSearchRow";
            this.pnlSearchRow.Size = new System.Drawing.Size(715, 60);
            this.pnlSearchRow.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(20, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(560, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(595, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 32);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlForm (left, big)
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblFormTitle);
            this.pnlForm.Controls.Add(this.lblTitleField);
            this.pnlForm.Controls.Add(this.txtTitle);
            this.pnlForm.Controls.Add(this.lblAudienceField);
            this.pnlForm.Controls.Add(this.cmbAudience);
            this.pnlForm.Controls.Add(this.lblContentField);
            this.pnlForm.Controls.Add(this.txtContent);
            this.pnlForm.Controls.Add(this.btnPost);
            this.pnlForm.Controls.Add(this.btnArchive);
            this.pnlForm.Controls.Add(this.btnCancel);
            this.pnlForm.Location = new System.Drawing.Point(30, 165);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(715, 495);
            this.pnlForm.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblFormTitle.Location = new System.Drawing.Point(20, 18);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(280, 25);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "New Announcement";
            // 
            // lblTitleField
            // 
            this.lblTitleField.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitleField.Location = new System.Drawing.Point(20, 60);
            this.lblTitleField.Name = "lblTitleField";
            this.lblTitleField.Size = new System.Drawing.Size(200, 18);
            this.lblTitleField.TabIndex = 1;
            this.lblTitleField.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(20, 82);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(675, 25);
            this.txtTitle.TabIndex = 2;
            // 
            // lblAudienceField
            // 
            this.lblAudienceField.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAudienceField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblAudienceField.Location = new System.Drawing.Point(20, 130);
            this.lblAudienceField.Name = "lblAudienceField";
            this.lblAudienceField.Size = new System.Drawing.Size(200, 18);
            this.lblAudienceField.TabIndex = 3;
            this.lblAudienceField.Text = "Target Audience";
            // 
            // cmbAudience
            // 
            this.cmbAudience.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudience.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAudience.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAudience.FormattingEnabled = true;
            this.cmbAudience.Items.AddRange(new object[] {
                "All",
                "Students",
                "Faculty"
            });
            this.cmbAudience.Location = new System.Drawing.Point(20, 152);
            this.cmbAudience.Name = "cmbAudience";
            this.cmbAudience.Size = new System.Drawing.Size(675, 28);
            this.cmbAudience.TabIndex = 4;
            // 
            // lblContentField
            // 
            this.lblContentField.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContentField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblContentField.Location = new System.Drawing.Point(20, 200);
            this.lblContentField.Name = "lblContentField";
            this.lblContentField.Size = new System.Drawing.Size(200, 18);
            this.lblContentField.TabIndex = 5;
            this.lblContentField.Text = "Content";
            // 
            // txtContent
            // 
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.Location = new System.Drawing.Point(20, 222);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(675, 195);
            this.txtContent.TabIndex = 6;
            // 
            // btnPost
            // 
            this.btnPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.FlatAppearance.BorderSize = 0;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPost.ForeColor = System.Drawing.Color.White;
            this.btnPost.Location = new System.Drawing.Point(20, 440);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(165, 38);
            this.btnPost.TabIndex = 7;
            this.btnPost.Text = "Post Announcement";
            this.btnPost.UseVisualStyleBackColor = false;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.White;
            this.btnArchive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.btnArchive.FlatAppearance.BorderSize = 1;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnArchive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.btnArchive.Location = new System.Drawing.Point(200, 440);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(110, 38);
            this.btnArchive.TabIndex = 8;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.btnCancel.Location = new System.Drawing.Point(325, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlPosted
            // 
            this.pnlPosted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pnlPosted.Controls.Add(this.lblPostedTitle);
            this.pnlPosted.Controls.Add(this.pnlPostedList);
            this.pnlPosted.Location = new System.Drawing.Point(760, 90);
            this.pnlPosted.Name = "pnlPosted";
            this.pnlPosted.Size = new System.Drawing.Size(180, 485);
            this.pnlPosted.TabIndex = 3;
            // 
            // lblPostedTitle
            // 
            this.lblPostedTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPostedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblPostedTitle.Location = new System.Drawing.Point(0, 5);
            this.lblPostedTitle.Name = "lblPostedTitle";
            this.lblPostedTitle.Size = new System.Drawing.Size(180, 25);
            this.lblPostedTitle.TabIndex = 0;
            this.lblPostedTitle.Text = "Posted Announcements";
            // 
            // pnlPostedList
            // 
            this.pnlPostedList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pnlPostedList.Location = new System.Drawing.Point(0, 35);
            this.pnlPostedList.Name = "pnlPostedList";
            this.pnlPostedList.Size = new System.Drawing.Size(180, 445);
            this.pnlPostedList.TabIndex = 1;
            // 
            // pbWatermark
            // 
            this.pbWatermark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pbWatermark.Location = new System.Drawing.Point(845, 615);
            this.pbWatermark.Name = "pbWatermark";
            this.pbWatermark.Size = new System.Drawing.Size(90, 90);
            this.pbWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWatermark.TabIndex = 4;
            this.pbWatermark.TabStop = false;
            this.pbWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))));
            // 
            // frmPostAnnouncement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPostAnnouncement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniConnect — Post Announcement";
            this.Load += new System.EventHandler(this.frmPostAnnouncement_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).EndInit();
            this.pnlSidebarUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlSearchRow.ResumeLayout(false);
            this.pnlSearchRow.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlPosted.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermark)).EndInit();
            this.ResumeLayout(false);
        }
    }
}