namespace UniConnect
{
    partial class frmAdminDashboard
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

        // Stat cards
        private System.Windows.Forms.Panel pnlStudentsCard;
        private System.Windows.Forms.Label lblStudentsTitle;
        private System.Windows.Forms.Label lblStudentsValue;

        private System.Windows.Forms.Panel pnlCoursesCard;
        private System.Windows.Forms.Label lblCoursesTitle;
        private System.Windows.Forms.Label lblCoursesValue;

        private System.Windows.Forms.Panel pnlPendingCard;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingValue;

        private System.Windows.Forms.Panel pnlAnnouncementsCard;
        private System.Windows.Forms.Label lblAnnouncementsTitle;
        private System.Windows.Forms.Label lblAnnouncementsValue;

        // Recent grade entries
        private System.Windows.Forms.Panel pnlRecentGrades;
        private System.Windows.Forms.Label lblRecentGradesTitle;
        private System.Windows.Forms.DataGridView dgvRecentGrades;

        // Recent audit logs
        private System.Windows.Forms.Panel pnlAuditLogs;
        private System.Windows.Forms.Label lblAuditLogsTitle;
        private System.Windows.Forms.Panel pnlAuditList;

        // Watermark
        private System.Windows.Forms.PictureBox pbWatermark;

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
            this.pbUserAvatar = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblAdminPill = new System.Windows.Forms.Label();
            this.pnlStudentsCard = new System.Windows.Forms.Panel();
            this.lblStudentsTitle = new System.Windows.Forms.Label();
            this.lblStudentsValue = new System.Windows.Forms.Label();
            this.pnlCoursesCard = new System.Windows.Forms.Panel();
            this.lblCoursesTitle = new System.Windows.Forms.Label();
            this.lblCoursesValue = new System.Windows.Forms.Label();
            this.pnlPendingCard = new System.Windows.Forms.Panel();
            this.lblPendingTitle = new System.Windows.Forms.Label();
            this.lblPendingValue = new System.Windows.Forms.Label();
            this.pnlAnnouncementsCard = new System.Windows.Forms.Panel();
            this.lblAnnouncementsTitle = new System.Windows.Forms.Label();
            this.lblAnnouncementsValue = new System.Windows.Forms.Label();
            this.pnlRecentGrades = new System.Windows.Forms.Panel();
            this.lblRecentGradesTitle = new System.Windows.Forms.Label();
            this.dgvRecentGrades = new System.Windows.Forms.DataGridView();
            this.pnlAuditLogs = new System.Windows.Forms.Panel();
            this.lblAuditLogsTitle = new System.Windows.Forms.Label();
            this.pnlAuditList = new System.Windows.Forms.Panel();
            this.pbWatermark = new System.Windows.Forms.PictureBox();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).BeginInit();
            this.pnlSidebarUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlStudentsCard.SuspendLayout();
            this.pnlCoursesCard.SuspendLayout();
            this.pnlPendingCard.SuspendLayout();
            this.pnlAnnouncementsCard.SuspendLayout();
            this.pnlRecentGrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentGrades)).BeginInit();
            this.pnlAuditLogs.SuspendLayout();
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
            // btnNavDashboard (ACTIVE)
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
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
            // btnNavPostAnnouncement
            // 
            this.btnNavPostAnnouncement.BackColor = System.Drawing.Color.Transparent;
            this.btnNavPostAnnouncement.FlatAppearance.BorderSize = 0;
            this.btnNavPostAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPostAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9.5F);
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
            this.pnlMain.Controls.Add(this.pnlStudentsCard);
            this.pnlMain.Controls.Add(this.pnlCoursesCard);
            this.pnlMain.Controls.Add(this.pnlPendingCard);
            this.pnlMain.Controls.Add(this.pnlAnnouncementsCard);
            this.pnlMain.Controls.Add(this.pnlRecentGrades);
            this.pnlMain.Controls.Add(this.pnlAuditLogs);
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
            this.lblPageTitle.Text = "Admin Dashboard";
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
            // pnlStudentsCard
            // 
            this.pnlStudentsCard.BackColor = System.Drawing.Color.White;
            this.pnlStudentsCard.Controls.Add(this.lblStudentsTitle);
            this.pnlStudentsCard.Controls.Add(this.lblStudentsValue);
            this.pnlStudentsCard.Location = new System.Drawing.Point(30, 95);
            this.pnlStudentsCard.Name = "pnlStudentsCard";
            this.pnlStudentsCard.Size = new System.Drawing.Size(195, 100);
            this.pnlStudentsCard.TabIndex = 1;
            // 
            // lblStudentsTitle
            // 
            this.lblStudentsTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStudentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblStudentsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblStudentsTitle.Name = "lblStudentsTitle";
            this.lblStudentsTitle.Size = new System.Drawing.Size(160, 18);
            this.lblStudentsTitle.TabIndex = 0;
            this.lblStudentsTitle.Text = "Total Students";
            // 
            // lblStudentsValue
            // 
            this.lblStudentsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblStudentsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.lblStudentsValue.Location = new System.Drawing.Point(15, 38);
            this.lblStudentsValue.Name = "lblStudentsValue";
            this.lblStudentsValue.Size = new System.Drawing.Size(160, 45);
            this.lblStudentsValue.TabIndex = 1;
            this.lblStudentsValue.Text = "—";
            // 
            // pnlCoursesCard
            // 
            this.pnlCoursesCard.BackColor = System.Drawing.Color.White;
            this.pnlCoursesCard.Controls.Add(this.lblCoursesTitle);
            this.pnlCoursesCard.Controls.Add(this.lblCoursesValue);
            this.pnlCoursesCard.Location = new System.Drawing.Point(240, 95);
            this.pnlCoursesCard.Name = "pnlCoursesCard";
            this.pnlCoursesCard.Size = new System.Drawing.Size(195, 100);
            this.pnlCoursesCard.TabIndex = 2;
            // 
            // lblCoursesTitle
            // 
            this.lblCoursesTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCoursesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblCoursesTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCoursesTitle.Name = "lblCoursesTitle";
            this.lblCoursesTitle.Size = new System.Drawing.Size(160, 18);
            this.lblCoursesTitle.TabIndex = 0;
            this.lblCoursesTitle.Text = "Courses";
            // 
            // lblCoursesValue
            // 
            this.lblCoursesValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCoursesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCoursesValue.Location = new System.Drawing.Point(15, 38);
            this.lblCoursesValue.Name = "lblCoursesValue";
            this.lblCoursesValue.Size = new System.Drawing.Size(160, 45);
            this.lblCoursesValue.TabIndex = 1;
            this.lblCoursesValue.Text = "—";
            // 
            // pnlPendingCard
            // 
            this.pnlPendingCard.BackColor = System.Drawing.Color.White;
            this.pnlPendingCard.Controls.Add(this.lblPendingTitle);
            this.pnlPendingCard.Controls.Add(this.lblPendingValue);
            this.pnlPendingCard.Location = new System.Drawing.Point(450, 95);
            this.pnlPendingCard.Name = "pnlPendingCard";
            this.pnlPendingCard.Size = new System.Drawing.Size(195, 100);
            this.pnlPendingCard.TabIndex = 3;
            // 
            // lblPendingTitle
            // 
            this.lblPendingTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPendingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblPendingTitle.Location = new System.Drawing.Point(15, 15);
            this.lblPendingTitle.Name = "lblPendingTitle";
            this.lblPendingTitle.Size = new System.Drawing.Size(160, 18);
            this.lblPendingTitle.TabIndex = 0;
            this.lblPendingTitle.Text = "Pending Grades";
            // 
            // lblPendingValue
            // 
            this.lblPendingValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPendingValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblPendingValue.Location = new System.Drawing.Point(15, 38);
            this.lblPendingValue.Name = "lblPendingValue";
            this.lblPendingValue.Size = new System.Drawing.Size(160, 45);
            this.lblPendingValue.TabIndex = 1;
            this.lblPendingValue.Text = "—";
            // 
            // pnlAnnouncementsCard
            // 
            this.pnlAnnouncementsCard.BackColor = System.Drawing.Color.White;
            this.pnlAnnouncementsCard.Controls.Add(this.lblAnnouncementsTitle);
            this.pnlAnnouncementsCard.Controls.Add(this.lblAnnouncementsValue);
            this.pnlAnnouncementsCard.Location = new System.Drawing.Point(660, 95);
            this.pnlAnnouncementsCard.Name = "pnlAnnouncementsCard";
            this.pnlAnnouncementsCard.Size = new System.Drawing.Size(195, 100);
            this.pnlAnnouncementsCard.TabIndex = 4;
            // 
            // lblAnnouncementsTitle
            // 
            this.lblAnnouncementsTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblAnnouncementsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblAnnouncementsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAnnouncementsTitle.Name = "lblAnnouncementsTitle";
            this.lblAnnouncementsTitle.Size = new System.Drawing.Size(160, 18);
            this.lblAnnouncementsTitle.TabIndex = 0;
            this.lblAnnouncementsTitle.Text = "Announcements";
            // 
            // lblAnnouncementsValue
            // 
            this.lblAnnouncementsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAnnouncementsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblAnnouncementsValue.Location = new System.Drawing.Point(15, 38);
            this.lblAnnouncementsValue.Name = "lblAnnouncementsValue";
            this.lblAnnouncementsValue.Size = new System.Drawing.Size(160, 45);
            this.lblAnnouncementsValue.TabIndex = 1;
            this.lblAnnouncementsValue.Text = "—";
            // 
            // pnlRecentGrades
            // 
            this.pnlRecentGrades.BackColor = System.Drawing.Color.White;
            this.pnlRecentGrades.Controls.Add(this.lblRecentGradesTitle);
            this.pnlRecentGrades.Controls.Add(this.dgvRecentGrades);
            this.pnlRecentGrades.Location = new System.Drawing.Point(30, 215);
            this.pnlRecentGrades.Name = "pnlRecentGrades";
            this.pnlRecentGrades.Size = new System.Drawing.Size(715, 445);
            this.pnlRecentGrades.TabIndex = 5;
            // 
            // lblRecentGradesTitle
            // 
            this.lblRecentGradesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentGradesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblRecentGradesTitle.Location = new System.Drawing.Point(20, 18);
            this.lblRecentGradesTitle.Name = "lblRecentGradesTitle";
            this.lblRecentGradesTitle.Size = new System.Drawing.Size(280, 25);
            this.lblRecentGradesTitle.TabIndex = 0;
            this.lblRecentGradesTitle.Text = "Recent Grade Entries";
            // 
            // dgvRecentGrades
            // 
            this.dgvRecentGrades.AllowUserToAddRows = false;
            this.dgvRecentGrades.AllowUserToDeleteRows = false;
            this.dgvRecentGrades.AllowUserToResizeRows = false;
            this.dgvRecentGrades.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentGrades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentGrades.ColumnHeadersHeight = 38;
            this.dgvRecentGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentGrades.Location = new System.Drawing.Point(20, 55);
            this.dgvRecentGrades.Name = "dgvRecentGrades";
            this.dgvRecentGrades.ReadOnly = true;
            this.dgvRecentGrades.RowHeadersVisible = false;
            this.dgvRecentGrades.RowTemplate.Height = 32;
            this.dgvRecentGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentGrades.Size = new System.Drawing.Size(675, 370);
            this.dgvRecentGrades.TabIndex = 1;
            // 
            // pnlAuditLogs
            // 
            this.pnlAuditLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pnlAuditLogs.Controls.Add(this.lblAuditLogsTitle);
            this.pnlAuditLogs.Controls.Add(this.pnlAuditList);
            this.pnlAuditLogs.Location = new System.Drawing.Point(760, 215);
            this.pnlAuditLogs.Name = "pnlAuditLogs";
            this.pnlAuditLogs.Size = new System.Drawing.Size(180, 360);
            this.pnlAuditLogs.TabIndex = 6;
            // 
            // lblAuditLogsTitle
            // 
            this.lblAuditLogsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAuditLogsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblAuditLogsTitle.Location = new System.Drawing.Point(0, 5);
            this.lblAuditLogsTitle.Name = "lblAuditLogsTitle";
            this.lblAuditLogsTitle.Size = new System.Drawing.Size(250, 25);
            this.lblAuditLogsTitle.TabIndex = 0;
            this.lblAuditLogsTitle.Text = "Recent Audit Logs";
            // 
            // pnlAuditList
            // 
            this.pnlAuditList.AutoScroll = true;
            this.pnlAuditList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pnlAuditList.Location = new System.Drawing.Point(0, 40);
            this.pnlAuditList.Name = "pnlAuditList";
            this.pnlAuditList.Size = new System.Drawing.Size(180, 320);
            this.pnlAuditList.TabIndex = 1;
            // 
            // pbWatermark
            // 
            this.pbWatermark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pbWatermark.Location = new System.Drawing.Point(845, 615);
            this.pbWatermark.Name = "pbWatermark";
            this.pbWatermark.Size = new System.Drawing.Size(90, 90);
            this.pbWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWatermark.TabIndex = 7;
            this.pbWatermark.TabStop = false;
            this.pbWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))));
            // 
            // frmAdminDashboard
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
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniConnect — Admin Dashboard";
            this.Load += new System.EventHandler(this.frmAdminDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).EndInit();
            this.pnlSidebarUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlStudentsCard.ResumeLayout(false);
            this.pnlCoursesCard.ResumeLayout(false);
            this.pnlPendingCard.ResumeLayout(false);
            this.pnlAnnouncementsCard.ResumeLayout(false);
            this.pnlRecentGrades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentGrades)).EndInit();
            this.pnlAuditLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermark)).EndInit();
            this.ResumeLayout(false);
        }
    }
}