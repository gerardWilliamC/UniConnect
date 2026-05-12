using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

namespace UniConnect
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            LoadLogo();

            // Auth guard — only logged-in admins can be here
            if (Session.CurrentAdmin == null)
            {
                MessageBox.Show("Session expired. Please log in again.",
                    "Not signed in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new frmAdminLogin().Show();
                this.Close();
                return;
            }

            Admin me = Session.CurrentAdmin;
            DatabaseHelper db = new DatabaseHelper();

            try
            {
                // Sidebar — admin name and ID
                lblUserName.Text = me.FullName;
                lblUserId.Text = me.AdminId;

                // Top bar — admin role pill ("ICT Admin", "Registrar", etc.)
                lblAdminPill.Text = me.Role ?? "Admin";

                // Stat cards — all four counts in one query
                LoadStatCards(db);

                // Recent grade entries table
                StyleRecentGradesGrid();
                LoadRecentGrades(db);

                // Recent audit logs sidebar
                LoadRecentAuditLogs(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load admin dashboard.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        // =====================================================================
        // STAT CARDS
        // =====================================================================

        private void LoadStatCards(DatabaseHelper db)
        {
            var (totalStudents, totalCourses, pendingGrades, announcements) =
                db.GetAdminDashboardCounts();

            lblStudentsValue.Text = totalStudents.ToString();
            lblCoursesValue.Text = totalCourses.ToString();
            lblPendingValue.Text = pendingGrades.ToString();
            lblAnnouncementsValue.Text = announcements.ToString();
        }

        // =====================================================================
        // RECENT GRADE ENTRIES TABLE
        // =====================================================================

        private void StyleRecentGradesGrid()
        {
            dgvRecentGrades.EnableHeadersVisualStyles = false;
            dgvRecentGrades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(123, 31, 49);
            dgvRecentGrades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecentGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRecentGrades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRecentGrades.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvRecentGrades.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(123, 31, 49);
            dgvRecentGrades.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvRecentGrades.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvRecentGrades.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvRecentGrades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 232, 237);
            dgvRecentGrades.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 33, 33);
            dgvRecentGrades.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvRecentGrades.GridColor = Color.FromArgb(230, 230, 230);
            dgvRecentGrades.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRecentGrades.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            dgvRecentGrades.Columns.Clear();
            dgvRecentGrades.Columns.Add("Student", "Student");
            dgvRecentGrades.Columns.Add("SubjectCode", "Code");
            dgvRecentGrades.Columns.Add("SubjectName", "Subject");
            dgvRecentGrades.Columns.Add("Grade", "Grade");
            dgvRecentGrades.Columns.Add("Status", "Status");
            dgvRecentGrades.Columns.Add("EditedBy", "Edited By");
            dgvRecentGrades.Columns.Add("UpdatedAt", "When");

            dgvRecentGrades.Columns["Student"].Width = 140;
            dgvRecentGrades.Columns["SubjectCode"].Width = 65;
            dgvRecentGrades.Columns["SubjectName"].Width = 190;
            dgvRecentGrades.Columns["Grade"].Width = 60;
            dgvRecentGrades.Columns["Status"].Width = 70;
            dgvRecentGrades.Columns["EditedBy"].Width = 100;
            dgvRecentGrades.Columns["UpdatedAt"].Width = 80;
        }

        private void LoadRecentGrades(DatabaseHelper db)
        {
            // Clean up any old empty-state label
            foreach (var c in pnlRecentGrades.Controls.Find("lblEmptyRecentGrades", false))
                pnlRecentGrades.Controls.Remove(c);

            dgvRecentGrades.Rows.Clear();

            var rows = db.GetRecentGradeEntries(limit: 10);

            if (rows.Count == 0)
            {
                dgvRecentGrades.Visible = false;
                Label lblEmpty = new Label
                {
                    Name = "lblEmptyRecentGrades",
                    Text = "No grade entries yet",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = dgvRecentGrades.Location,
                    Size = dgvRecentGrades.Size,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                pnlRecentGrades.Controls.Add(lblEmpty);
                return;
            }

            dgvRecentGrades.Visible = true;

            foreach (var r in rows)
            {
                string gradeText = r.grade.HasValue ? r.grade.Value.ToString("0.00") : "—";
                string whenText = HumanizeTimeAgo(r.updatedAt);

                int rowIndex = dgvRecentGrades.Rows.Add(
                    r.studentName,
                    r.subjectCode,
                    r.subjectName,
                    gradeText,
                    r.status,
                    r.editedBy,
                    whenText);

                // Color-code the Status column
                var statusCell = dgvRecentGrades.Rows[rowIndex].Cells["Status"];
                if (r.status == "Passed")
                    statusCell.Style.ForeColor = Color.FromArgb(34, 139, 34);
                else if (r.status == "Failed")
                    statusCell.Style.ForeColor = Color.FromArgb(220, 38, 38);
                else
                    statusCell.Style.ForeColor = Color.FromArgb(217, 119, 6);
            }

            dgvRecentGrades.ClearSelection();
            dgvRecentGrades.CurrentCell = null;
        }

        // =====================================================================
        // RECENT AUDIT LOGS
        // =====================================================================

        private void LoadRecentAuditLogs(DatabaseHelper db)
        {
            pnlAuditList.Controls.Clear();
            pnlAuditList.AutoScroll = false;
            pnlAuditList.VerticalScroll.Value = 0;

            var logs = db.GetRecentAuditLogs(limit: 8);

            if (logs.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "No recent activity",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = new Point(0, 0),
                    Size = pnlAuditList.Size,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                pnlAuditList.Controls.Add(lblEmpty);
                return;
            }

            int y = 0;
            int itemWidth = pnlAuditList.Width - 5;

            foreach (var log in logs)
            {
                Panel item = BuildAuditLogItem(log, y, itemWidth);
                pnlAuditList.Controls.Add(item);
                y += item.Height + 6;
            }

            pnlAuditList.AutoScroll = true;
        }

        private Panel BuildAuditLogItem(AuditLog log, int y, int width)
        {
            Panel item = new Panel
            {
                BackColor = Color.Transparent,
                Location = new Point(0, y),
                Size = new Size(width, 56),
                BorderStyle = BorderStyle.None
            };

            // Left dot accent — color by action type
            Color dotColor = log.ActionType != null && log.ActionType.StartsWith("Grade")
                ? Color.FromArgb(34, 139, 34)
                : Color.FromArgb(123, 31, 49);

            Panel dot = new Panel
            {
                BackColor = dotColor,
                Location = new Point(0, 8),
                Size = new Size(4, 38)
            };
            item.Controls.Add(dot);

            // Action type (bold)
            var lblAction = new Label
            {
                Text = log.ActionType ?? "Action",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(10, 4),
                Size = new Size(width - 15, 16),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblAction);

            // Details (truncated)
            var lblDetails = new Label
            {
                Text = log.Details ?? "",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(10, 21),
                Size = new Size(width - 15, 15),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblDetails);

            // Footer: who + when
            string footer = (log.PerformedByName ?? log.PerformedBy ?? "—")
                + "  •  " + HumanizeTimeAgo(log.Timestamp);
            var lblFooter = new Label
            {
                Text = footer,
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(10, 38),
                Size = new Size(width - 15, 14),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblFooter);

            return item;
        }

        // =====================================================================
        // HELPERS
        // =====================================================================

        private string HumanizeTimeAgo(DateTime when)
        {
            TimeSpan diff = DateTime.Now - when;
            if (diff.TotalSeconds < 60) return "Just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes}m ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours}h ago";
            if (diff.TotalDays < 7) return $"{(int)diff.TotalDays}d ago";
            return when.ToString("MMM d");
        }

        // =====================================================================
        // SIDEBAR NAVIGATION
        // =====================================================================

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            // Already on Admin Dashboard
        }

        private void btnNavStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Students — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavEncodeGrades_Click(object sender, EventArgs e)
        {
            new frmEncodeGrades().Show();
            this.Close();
        }

        private void btnNavEnrollments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Enrollments — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavPostAnnouncement_Click(object sender, EventArgs e)
        {
            new frmPostAnnouncement().Show();
            this.Close();
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generate Reports — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavAuditLogs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Audit Logs (full view) — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}