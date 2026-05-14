namespace UniConnect
{
    partial class frmStudentDashboard
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

        // Top bar (NEW)
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblSemPill;

        // Stat cards
        private System.Windows.Forms.Panel pnlGwaCard;
        private System.Windows.Forms.Label lblGwaTitle;
        private System.Windows.Forms.Label lblGwaValue;
        private System.Windows.Forms.Label lblGwaSub;

        private System.Windows.Forms.Panel pnlUnitsCard;
        private System.Windows.Forms.Label lblUnitsTitle;
        private System.Windows.Forms.Label lblUnitsValue;
        private System.Windows.Forms.Label lblUnitsSub;

        private System.Windows.Forms.Panel pnlYearCard;
        private System.Windows.Forms.Label lblYearTitle;
        private System.Windows.Forms.Label lblYearValue;
        private System.Windows.Forms.Label lblYearSub;

        // Grades preview
        private System.Windows.Forms.Panel pnlGrades;
        private System.Windows.Forms.Label lblGradesTitle;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Button btnViewFullGrades;

        // Announcements
        private System.Windows.Forms.Panel pnlAnnouncements;
        private System.Windows.Forms.Label lblAnnTitle;
        private System.Windows.Forms.Panel pnlAnnList;

        // Bottom-right watermark logo (NEW)
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
            this.btnLogout.Location = new System.Drawing.Point(155, 10); // Positions it to the right
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(30, 40);
            this.btnLogout.Text = "➔"; // Matching your web portal icon
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.pbUserAvatar = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblSemPill = new System.Windows.Forms.Label();
            this.pnlGwaCard = new System.Windows.Forms.Panel();
            this.lblGwaTitle = new System.Windows.Forms.Label();
            this.lblGwaValue = new System.Windows.Forms.Label();
            this.lblGwaSub = new System.Windows.Forms.Label();
            this.pnlUnitsCard = new System.Windows.Forms.Panel();
            this.lblUnitsTitle = new System.Windows.Forms.Label();
            this.lblUnitsValue = new System.Windows.Forms.Label();
            this.lblUnitsSub = new System.Windows.Forms.Label();
            this.pnlYearCard = new System.Windows.Forms.Panel();
            this.lblYearTitle = new System.Windows.Forms.Label();
            this.lblYearValue = new System.Windows.Forms.Label();
            this.lblYearSub = new System.Windows.Forms.Label();
            this.pnlGrades = new System.Windows.Forms.Panel();
            this.lblGradesTitle = new System.Windows.Forms.Label();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.btnViewFullGrades = new System.Windows.Forms.Button();
            this.pnlAnnouncements = new System.Windows.Forms.Panel();
            this.lblAnnTitle = new System.Windows.Forms.Label();
            this.pnlAnnList = new System.Windows.Forms.Panel();
            this.pbWatermark = new System.Windows.Forms.PictureBox();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).BeginInit();
            this.pnlSidebarUser.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlGwaCard.SuspendLayout();
            this.pnlUnitsCard.SuspendLayout();
            this.pnlYearCard.SuspendLayout();
            this.pnlGrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.pnlAnnouncements.SuspendLayout();
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
            // 
            // sidebar header divider line
            // 
            System.Windows.Forms.Panel pnlSidebarHeaderLine = new System.Windows.Forms.Panel();
            pnlSidebarHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            pnlSidebarHeaderLine.Location = new System.Drawing.Point(15, 80);
            pnlSidebarHeaderLine.Size = new System.Drawing.Size(190, 1);
            pnlSidebarHeaderLine.Name = "pnlSidebarHeaderLine";
            this.pnlSidebar.Controls.Add(pnlSidebarHeaderLine);
            // 
            // sidebar footer divider line
            // 
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
            // btnNavAnnouncements
            // 
            this.btnNavAnnouncements.BackColor = System.Drawing.Color.Transparent;
            this.btnNavAnnouncements.FlatAppearance.BorderSize = 0;
            this.btnNavAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAnnouncements.Font = new System.Drawing.Font("Segoe UI", 9.5F);
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
            this.pnlMain.Controls.Add(this.pnlGwaCard);
            this.pnlMain.Controls.Add(this.pnlUnitsCard);
            this.pnlMain.Controls.Add(this.pnlYearCard);
            this.pnlMain.Controls.Add(this.pnlGrades);
            this.pnlMain.Controls.Add(this.pnlAnnouncements);
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
            this.lblPageTitle.Text = "Dashboard";
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
            // pnlGwaCard
            // 
            this.pnlGwaCard.BackColor = System.Drawing.Color.White;
            this.pnlGwaCard.Controls.Add(this.lblGwaTitle);
            this.pnlGwaCard.Controls.Add(this.lblGwaValue);
            this.pnlGwaCard.Controls.Add(this.lblGwaSub);
            this.pnlGwaCard.Location = new System.Drawing.Point(30, 95);
            this.pnlGwaCard.Name = "pnlGwaCard";
            this.pnlGwaCard.Size = new System.Drawing.Size(190, 110);
            this.pnlGwaCard.TabIndex = 2;
            // 
            // lblGwaTitle
            // 
            this.lblGwaTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGwaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblGwaTitle.Location = new System.Drawing.Point(15, 15);
            this.lblGwaTitle.Name = "lblGwaTitle";
            this.lblGwaTitle.Size = new System.Drawing.Size(160, 18);
            this.lblGwaTitle.TabIndex = 0;
            this.lblGwaTitle.Text = "GWA";
            // 
            // lblGwaValue
            // 
            this.lblGwaValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblGwaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(49)))));
            this.lblGwaValue.Location = new System.Drawing.Point(15, 38);
            this.lblGwaValue.Name = "lblGwaValue";
            this.lblGwaValue.Size = new System.Drawing.Size(160, 40);
            this.lblGwaValue.TabIndex = 1;
            this.lblGwaValue.Text = "—";
            // 
            // lblGwaSub
            // 
            this.lblGwaSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblGwaSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblGwaSub.Location = new System.Drawing.Point(15, 80);
            this.lblGwaSub.Name = "lblGwaSub";
            this.lblGwaSub.Size = new System.Drawing.Size(160, 18);
            this.lblGwaSub.TabIndex = 2;
            this.lblGwaSub.Text = "No data yet";
            // 
            // pnlUnitsCard
            // 
            this.pnlUnitsCard.BackColor = System.Drawing.Color.White;
            this.pnlUnitsCard.Controls.Add(this.lblUnitsTitle);
            this.pnlUnitsCard.Controls.Add(this.lblUnitsValue);
            this.pnlUnitsCard.Controls.Add(this.lblUnitsSub);
            this.pnlUnitsCard.Location = new System.Drawing.Point(235, 95);
            this.pnlUnitsCard.Name = "pnlUnitsCard";
            this.pnlUnitsCard.Size = new System.Drawing.Size(190, 110);
            this.pnlUnitsCard.TabIndex = 3;
            // 
            // lblUnitsTitle
            // 
            this.lblUnitsTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUnitsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblUnitsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblUnitsTitle.Name = "lblUnitsTitle";
            this.lblUnitsTitle.Size = new System.Drawing.Size(160, 18);
            this.lblUnitsTitle.TabIndex = 0;
            this.lblUnitsTitle.Text = "Enrolled Units";
            // 
            // lblUnitsValue
            // 
            this.lblUnitsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblUnitsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblUnitsValue.Location = new System.Drawing.Point(15, 38);
            this.lblUnitsValue.Name = "lblUnitsValue";
            this.lblUnitsValue.Size = new System.Drawing.Size(160, 40);
            this.lblUnitsValue.TabIndex = 1;
            this.lblUnitsValue.Text = "—";
            // 
            // lblUnitsSub
            // 
            this.lblUnitsSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUnitsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblUnitsSub.Location = new System.Drawing.Point(15, 80);
            this.lblUnitsSub.Name = "lblUnitsSub";
            this.lblUnitsSub.Size = new System.Drawing.Size(160, 18);
            this.lblUnitsSub.TabIndex = 2;
            this.lblUnitsSub.Text = "No data yet";
            // 
            // pnlYearCard
            // 
            this.pnlYearCard.BackColor = System.Drawing.Color.White;
            this.pnlYearCard.Controls.Add(this.lblYearTitle);
            this.pnlYearCard.Controls.Add(this.lblYearValue);
            this.pnlYearCard.Controls.Add(this.lblYearSub);
            this.pnlYearCard.Location = new System.Drawing.Point(440, 95);
            this.pnlYearCard.Name = "pnlYearCard";
            this.pnlYearCard.Size = new System.Drawing.Size(190, 110);
            this.pnlYearCard.TabIndex = 4;
            // 
            // lblYearTitle
            // 
            this.lblYearTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblYearTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblYearTitle.Location = new System.Drawing.Point(15, 15);
            this.lblYearTitle.Name = "lblYearTitle";
            this.lblYearTitle.Size = new System.Drawing.Size(160, 18);
            this.lblYearTitle.TabIndex = 0;
            this.lblYearTitle.Text = "Year Level";
            // 
            // lblYearValue
            // 
            this.lblYearValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblYearValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblYearValue.Location = new System.Drawing.Point(15, 38);
            this.lblYearValue.Name = "lblYearValue";
            this.lblYearValue.Size = new System.Drawing.Size(160, 40);
            this.lblYearValue.TabIndex = 1;
            this.lblYearValue.Text = "—";
            // 
            // lblYearSub
            // 
            this.lblYearSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblYearSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.lblYearSub.Location = new System.Drawing.Point(15, 80);
            this.lblYearSub.Name = "lblYearSub";
            this.lblYearSub.Size = new System.Drawing.Size(160, 18);
            this.lblYearSub.TabIndex = 2;
            this.lblYearSub.Text = "No data yet";
            // 
            // pnlGrades
            // 
            this.pnlGrades.BackColor = System.Drawing.Color.White;
            this.pnlGrades.Controls.Add(this.lblGradesTitle);
            this.pnlGrades.Controls.Add(this.dgvGrades);
            this.pnlGrades.Controls.Add(this.btnViewFullGrades);
            this.pnlGrades.Location = new System.Drawing.Point(30, 225);
            this.pnlGrades.Name = "pnlGrades";
            this.pnlGrades.Size = new System.Drawing.Size(600, 460);
            this.pnlGrades.TabIndex = 5;
            // 
            // lblGradesTitle
            // 
            this.lblGradesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGradesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblGradesTitle.Location = new System.Drawing.Point(20, 18);
            this.lblGradesTitle.Name = "lblGradesTitle";
            this.lblGradesTitle.Size = new System.Drawing.Size(200, 25);
            this.lblGradesTitle.TabIndex = 0;
            this.lblGradesTitle.Text = "My Grades";
            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.AllowUserToResizeRows = false;
            this.dgvGrades.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGrades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGrades.ColumnHeadersHeight = 38;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrades.Location = new System.Drawing.Point(20, 55);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.ReadOnly = true;
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.RowTemplate.Height = 32;
            this.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrades.Size = new System.Drawing.Size(560, 340);
            this.dgvGrades.TabIndex = 1;
            // 
            // btnViewFullGrades
            // 
            this.btnViewFullGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnViewFullGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewFullGrades.FlatAppearance.BorderSize = 0;
            this.btnViewFullGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewFullGrades.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewFullGrades.ForeColor = System.Drawing.Color.White;
            this.btnViewFullGrades.Location = new System.Drawing.Point(20, 410);
            this.btnViewFullGrades.Name = "btnViewFullGrades";
            this.btnViewFullGrades.Size = new System.Drawing.Size(180, 36);
            this.btnViewFullGrades.TabIndex = 2;
            this.btnViewFullGrades.Text = "View Full Grade Report";
            this.btnViewFullGrades.UseVisualStyleBackColor = false;
            this.btnViewFullGrades.Click += new System.EventHandler(this.btnViewFullGrades_Click);
            // 
            // pnlAnnouncements
            // 
            this.pnlAnnouncements.BackColor = System.Drawing.Color.White;
            this.pnlAnnouncements.Controls.Add(this.lblAnnTitle);
            this.pnlAnnouncements.Controls.Add(this.pnlAnnList);
            this.pnlAnnouncements.Location = new System.Drawing.Point(645, 225);
            this.pnlAnnouncements.Name = "pnlAnnouncements";
            this.pnlAnnouncements.Size = new System.Drawing.Size(285, 230);
            this.pnlAnnouncements.TabIndex = 6;
            // 
            // lblAnnTitle
            // 
            this.lblAnnTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAnnTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblAnnTitle.Location = new System.Drawing.Point(20, 18);
            this.lblAnnTitle.Name = "lblAnnTitle";
            this.lblAnnTitle.Size = new System.Drawing.Size(200, 25);
            this.lblAnnTitle.TabIndex = 0;
            this.lblAnnTitle.Text = "Notifications";
            // 
            // pnlAnnList
            // 
            this.pnlAnnList.AutoScroll = true;
            this.pnlAnnList.BackColor = System.Drawing.Color.White;
            this.pnlAnnList.Location = new System.Drawing.Point(15, 55);
            this.pnlAnnList.Name = "pnlAnnList";
            this.pnlAnnList.Size = new System.Drawing.Size(255, 160);
            this.pnlAnnList.TabIndex = 1;
            // 
            // pbWatermark
            // 
            this.pbWatermark.BackColor = System.Drawing.Color.Transparent;
            this.pbWatermark.Location = new System.Drawing.Point(845, 615);
            this.pbWatermark.Name = "pbWatermark";
            this.pbWatermark.Size = new System.Drawing.Size(90, 90);
            this.pbWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWatermark.TabIndex = 7;
            this.pbWatermark.TabStop = false;
            this.pbWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))));
            // 
            // frmStudentDashboard
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
            this.Name = "frmStudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniConnect — Dashboard";
            this.Load += new System.EventHandler(this.frmStudentDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSidebarLogo)).EndInit();
            this.pnlSidebarUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAvatar)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlGwaCard.ResumeLayout(false);
            this.pnlUnitsCard.ResumeLayout(false);
            this.pnlYearCard.ResumeLayout(false);
            this.pnlGrades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.pnlAnnouncements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWatermark)).EndInit();
            this.ResumeLayout(false);
        }
    }
}