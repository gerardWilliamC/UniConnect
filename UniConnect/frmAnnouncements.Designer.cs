namespace UniConnect
{
    partial class frmAnnouncements
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox pbSidebarLogo;
        private System.Windows.Forms.Label lblSidebarBrand;
        private System.Windows.Forms.Label lblSidebarSub;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavGrades;
        private System.Windows.Forms.Button btnNavSchedule;
        private System.Windows.Forms.Button btnNavEnrollments;
        private System.Windows.Forms.Button btnNavAnnouncements;
        private System.Windows.Forms.Button btnNavProfile;
        private System.Windows.Forms.Panel pnlSidebarUser;
        private System.Windows.Forms.PictureBox pbUserAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserId;

        // Main content
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblSemPill;

        // Latest announcements (left, big)
        private System.Windows.Forms.Panel pnlLatest;
        private System.Windows.Forms.Label lblLatestTitle;
        private System.Windows.Forms.Panel pnlLatestList;

        // Quick info (right, small)
        private System.Windows.Forms.Panel pnlQuickInfo;
        private System.Windows.Forms.Label lblQuickTitle;
        private System.Windows.Forms.Label lblUnreadLabel;
        private System.Windows.Forms.Label lblUnreadCount;

        // Search (below quick info)
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

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
            this.btnNavGrades = new System.Windows.Forms.Button();
            this.btnNavSchedule = new System.Windows.Forms.Button();
            this.btnNavEnrollments = new System.Windows.Forms.Button();
            this.btnNavAnnouncements = new System.Windows.Forms.Button();
            this.btnNavProfile = new System.Windows.Forms.Button();
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
            this.lblSemPill = new System.Windows.Forms.Label();
            this.pnlLatest = new System.Windows.Forms.Panel();
            this.lblLatestTitle = new System.Windows.Forms.Label();
            this.pnlLatestList = new System.Windows.Forms.Panel();
            this.pnlQuickInfo = new System.Windows.Forms.Panel();
            this.lblQuickTitle = new System.Windows.Forms.Label();
            this.lblUnreadLabel = new System.Windows.Forms.Label();
            this.lblUnreadCount = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbWatermark = new System.Windows.Forms.PictureBox();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).BeginInit();
            this.pnlSidebarUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlLatest.SuspendLayout();
            this.pnlQuickInfo.SuspendLayout();
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
            this.pnlSidebar.Controls.Add(this.btnNavGrades);
            this.pnlSidebar.Controls.Add(this.btnNavSchedule);
            this.pnlSidebar.Controls.Add(this.btnNavEnrollments);
            this.pnlSidebar.Controls.Add(this.btnNavAnnouncements);
            this.pnlSidebar.Controls.Add(this.btnNavProfile);
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
            this.lblSidebarSub.Text = "Student Portal";
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
            // btnNavGrades
            // 
            this.btnNavGrades.BackColor = System.Drawing.Color.Transparent;
            this.btnNavGrades.FlatAppearance.BorderSize = 0;
            this.btnNavGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavGrades.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavGrades.ForeColor = System.Drawing.Color.White;
            this.btnNavGrades.Location = new System.Drawing.Point(15, 145);
            this.btnNavGrades.Name = "btnNavGrades";
            this.btnNavGrades.Size = new System.Drawing.Size(190, 38);
            this.btnNavGrades.TabIndex = 4;
            this.btnNavGrades.Text = "  My Grades";
            this.btnNavGrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavGrades.UseVisualStyleBackColor = false;
            this.btnNavGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavGrades.Click += new System.EventHandler(this.btnNavGrades_Click);
            // 
            // btnNavSchedule
            // 
            this.btnNavSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnNavSchedule.FlatAppearance.BorderSize = 0;
            this.btnNavSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSchedule.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavSchedule.ForeColor = System.Drawing.Color.White;
            this.btnNavSchedule.Location = new System.Drawing.Point(15, 190);
            this.btnNavSchedule.Name = "btnNavSchedule";
            this.btnNavSchedule.Size = new System.Drawing.Size(190, 38);
            this.btnNavSchedule.TabIndex = 5;
            this.btnNavSchedule.Text = "  Schedule";
            this.btnNavSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSchedule.UseVisualStyleBackColor = false;
            this.btnNavSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSchedule.Click += new System.EventHandler(this.btnNavSchedule_Click);
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
            this.btnNavEnrollments.Text = "  Enrollments";
            this.btnNavEnrollments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavEnrollments.UseVisualStyleBackColor = false;
            this.btnNavEnrollments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavEnrollments.Click += new System.EventHandler(this.btnNavEnrollments_Click);
            // 
            // btnNavAnnouncements (ACTIVE on this page)
            // 
            this.btnNavAnnouncements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.btnNavAnnouncements.FlatAppearance.BorderSize = 0;
            this.btnNavAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAnnouncements.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavAnnouncements.ForeColor = System.Drawing.Color.White;
            this.btnNavAnnouncements.Location = new System.Drawing.Point(15, 280);
            this.btnNavAnnouncements.Name = "btnNavAnnouncements";
            this.btnNavAnnouncements.Size = new System.Drawing.Size(190, 38);
            this.btnNavAnnouncements.TabIndex = 7;
            this.btnNavAnnouncements.Text = "  Announcements";
            this.btnNavAnnouncements.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAnnouncements.UseVisualStyleBackColor = false;
            this.btnNavAnnouncements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAnnouncements.Click += new System.EventHandler(this.btnNavAnnouncements_Click);
            // 
            // btnNavProfile
            // 
            this.btnNavProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnNavProfile.FlatAppearance.BorderSize = 0;
            this.btnNavProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProfile.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavProfile.ForeColor = System.Drawing.Color.White;
            this.btnNavProfile.Location = new System.Drawing.Point(15, 325);
            this.btnNavProfile.Name = "btnNavProfile";
            this.btnNavProfile.Size = new System.Drawing.Size(190, 38);
            this.btnNavProfile.TabIndex = 8;
            this.btnNavProfile.Text = "  My Profile";
            this.btnNavProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProfile.UseVisualStyleBackColor = false;
            this.btnNavProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavProfile.Click += new System.EventHandler(this.btnNavProfile_Click);
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
            this.pnlSidebarUser.TabIndex = 9;
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
            this.lblUserName.Text = "Juan dela Cruz";
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
            this.lblUserId.Text = "2024-00001";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pnlMain.Controls.Add(this.pnlTopBar);
            this.pnlMain.Controls.Add(this.pnlLatest);
            this.pnlMain.Controls.Add(this.pnlQuickInfo);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Controls.Add(this.btnSearch);
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
            this.pnlTopBar.Controls.Add(this.lblSemPill);
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
            this.lblPageTitle.Text = "Announcements";
            // 
            // lblSemPill
            // 
            this.lblSemPill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.lblSemPill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSemPill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.lblSemPill.Location = new System.Drawing.Point(740, 22);
            this.lblSemPill.Name = "lblSemPill";
            this.lblSemPill.Size = new System.Drawing.Size(190, 28);
            this.lblSemPill.TabIndex = 1;
            this.lblSemPill.Text = "2nd Sem — AY 2025-2026";
            this.lblSemPill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLatest (left, big container for announcements)
            // 
            this.pnlLatest.BackColor = System.Drawing.Color.White;
            this.pnlLatest.Controls.Add(this.lblLatestTitle);
            this.pnlLatest.Controls.Add(this.pnlLatestList);
            this.pnlLatest.Location = new System.Drawing.Point(30, 95);
            this.pnlLatest.Name = "pnlLatest";
            this.pnlLatest.Size = new System.Drawing.Size(665, 565);
            this.pnlLatest.TabIndex = 1;
            // 
            // lblLatestTitle
            // 
            this.lblLatestTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLatestTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblLatestTitle.Location = new System.Drawing.Point(20, 18);
            this.lblLatestTitle.Name = "lblLatestTitle";
            this.lblLatestTitle.Size = new System.Drawing.Size(300, 25);
            this.lblLatestTitle.TabIndex = 0;
            this.lblLatestTitle.Text = "Latest Announcements";
            // 
            // pnlLatestList (scrollable list of announcement cards)
            // 
            this.pnlLatestList.AutoScroll = true;
            this.pnlLatestList.BackColor = System.Drawing.Color.White;
            this.pnlLatestList.Location = new System.Drawing.Point(15, 55);
            this.pnlLatestList.Name = "pnlLatestList";
            this.pnlLatestList.Size = new System.Drawing.Size(635, 495);
            this.pnlLatestList.TabIndex = 1;
            // 
            // pnlQuickInfo (right, small)
            // 
            this.pnlQuickInfo.BackColor = System.Drawing.Color.White;
            this.pnlQuickInfo.Controls.Add(this.lblQuickTitle);
            this.pnlQuickInfo.Controls.Add(this.lblUnreadLabel);
            this.pnlQuickInfo.Controls.Add(this.lblUnreadCount);
            this.pnlQuickInfo.Location = new System.Drawing.Point(715, 95);
            this.pnlQuickInfo.Name = "pnlQuickInfo";
            this.pnlQuickInfo.Size = new System.Drawing.Size(190, 200);
            this.pnlQuickInfo.TabIndex = 2;
            // 
            // lblQuickTitle
            // 
            this.lblQuickTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuickTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblQuickTitle.Location = new System.Drawing.Point(15, 15);
            this.lblQuickTitle.Name = "lblQuickTitle";
            this.lblQuickTitle.Size = new System.Drawing.Size(160, 25);
            this.lblQuickTitle.TabIndex = 0;
            this.lblQuickTitle.Text = "Quick Info";
            // 
            // lblUnreadLabel
            // 
            this.lblUnreadLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUnreadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblUnreadLabel.Location = new System.Drawing.Point(15, 55);
            this.lblUnreadLabel.Name = "lblUnreadLabel";
            this.lblUnreadLabel.Size = new System.Drawing.Size(160, 18);
            this.lblUnreadLabel.TabIndex = 1;
            this.lblUnreadLabel.Text = "Unread Announcements";
            // 
            // lblUnreadCount
            // 
            this.lblUnreadCount.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblUnreadCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.lblUnreadCount.Location = new System.Drawing.Point(15, 80);
            this.lblUnreadCount.Name = "lblUnreadCount";
            this.lblUnreadCount.Size = new System.Drawing.Size(160, 70);
            this.lblUnreadCount.TabIndex = 2;
            this.lblUnreadCount.Text = "0";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(715, 315);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(125, 30);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(845, 315);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pbWatermark
            // 
            this.pbWatermark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.pbWatermark.Location = new System.Drawing.Point(845, 615);
            this.pbWatermark.Name = "pbWatermark";
            this.pbWatermark.Size = new System.Drawing.Size(90, 90);
            this.pbWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWatermark.TabIndex = 3;
            this.pbWatermark.TabStop = false;
            this.pbWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))));
            // 
            // frmAnnouncements
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
            this.Name = "frmAnnouncements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniConnect — Announcements";
            this.Load += new System.EventHandler(this.frmAnnouncements_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).EndInit();
            this.pnlSidebarUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlLatest.ResumeLayout(false);
            this.pnlQuickInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermark)).EndInit();
            this.ResumeLayout(false);
        }
    }
}