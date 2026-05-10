using System;
using System.Drawing;
using System.Windows.Forms;

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
            StyleRecentGradesGrid();
            LoadRecentGrades();    // empty for now
            LoadAuditLogs();       // empty for now
            ResetStatCards();
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

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
            dgvRecentGrades.Columns.Add("Subject", "Subject");
            dgvRecentGrades.Columns.Add("Grade", "Grade");
            dgvRecentGrades.Columns.Add("UpdatedBy", "Updated By");
            dgvRecentGrades.Columns.Add("Date", "Date");

            dgvRecentGrades.Columns["Student"].Width = 120;
            dgvRecentGrades.Columns["Subject"].Width = 110;
            dgvRecentGrades.Columns["Grade"].Width = 60;
            dgvRecentGrades.Columns["UpdatedBy"].Width = 95;
            dgvRecentGrades.Columns["Date"].Width = 80;
        }

        private void LoadRecentGrades()
        {
            // Remove any old empty-state label so we don't stack them
            var existing = pnlRecentGrades.Controls.Find("lblEmptyGrades", false);
            foreach (var c in existing) pnlRecentGrades.Controls.Remove(c);

            // TODO: replace with SQL query later
            dgvRecentGrades.Rows.Clear();

            if (dgvRecentGrades.Rows.Count == 0)
                ShowEmptyGradesMessage();

            dgvRecentGrades.ClearSelection();
            dgvRecentGrades.CurrentCell = null;
        }

        private void ShowEmptyGradesMessage()
        {
            dgvRecentGrades.Visible = false;

            Label lblEmpty = new Label
            {
                Name = "lblEmptyGrades",
                Text = "No recent grade entries",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(20, 55),
                Size = new Size(575, 370),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlRecentGrades.Controls.Add(lblEmpty);
        }

        private void LoadAuditLogs()
        {
            // TODO: replace with SQL query later
            pnlAuditList.Controls.Clear();

            int logCount = 0;

            if (logCount == 0)
            {
                pnlAuditList.AutoScroll = false;   // no scrollbar for empty state
                ShowEmptyAuditMessage();
            }
            else
            {
                pnlAuditList.AutoScroll = true;    // re-enable when there's actual data to scroll
            }
        }

        private void ShowEmptyAuditMessage()
        {
            Label lblEmpty = new Label
            {
                Text = "No recent audit logs",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(0, 0),
                Size = new Size(180, 320),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = System.Drawing.Color.FromArgb(245, 243, 248)
            };
            pnlAuditList.Controls.Add(lblEmpty);
        }

        private void ResetStatCards()
        {
            lblStudentsValue.Text = "—";
            lblCoursesValue.Text = "—";
            lblPendingValue.Text = "—";
            lblAnnouncementsValue.Text = "—";
        }

        // ===== Sidebar nav =====
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            // Already here
        }

        private void btnNavStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Students page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavEncodeGrades_Click(object sender, EventArgs e)
        {
            frmEncodeGrades f = new frmEncodeGrades();
            f.Show();
            this.Close();
        }

        private void btnNavEnrollments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Enrollments page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavPostAnnouncement_Click(object sender, EventArgs e)
        {
            frmPostAnnouncement f = new frmPostAnnouncement();
            f.Show();
            this.Close();
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generate Reports page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavAuditLogs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Audit Logs page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}