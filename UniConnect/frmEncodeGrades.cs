using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniConnect
{
    public partial class frmEncodeGrades : Form
    {
        public frmEncodeGrades()
        {
            InitializeComponent();
        }

        private void frmEncodeGrades_Load(object sender, EventArgs e)
        {
            LoadLogo();
            StyleGradesGrid();
            LoadGrades();
            LoadRecentChanges();
            SetupSearchPlaceholder();
        }

        private void SetupSearchPlaceholder()
        {
            string placeholder = "Search students by ID or name...";
            txtSearch.Text = placeholder;
            txtSearch.ForeColor = Color.FromArgb(160, 160, 160);

            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == placeholder)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.FromArgb(33, 33, 33);
                }
            };

            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = placeholder;
                    txtSearch.ForeColor = Color.FromArgb(160, 160, 160);
                }
            };
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        private void StyleGradesGrid()
        {
            // Header
            dgvGrades.EnableHeadersVisualStyles = false;
            dgvGrades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(123, 31, 49);
            dgvGrades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvGrades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGrades.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(123, 31, 49);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Rows
            dgvGrades.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvGrades.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvGrades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 232, 237);
            dgvGrades.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 33, 33);
            dgvGrades.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvGrades.GridColor = Color.FromArgb(230, 230, 230);
            dgvGrades.RowsDefaultCellStyle.BackColor = Color.White;
            dgvGrades.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            // Build columns
            dgvGrades.Columns.Clear();
            dgvGrades.Columns.Add("StudentId", "Student ID");
            dgvGrades.Columns.Add("StudentName", "Student Name");
            dgvGrades.Columns.Add("Subject", "Subject");
            dgvGrades.Columns.Add("Code", "Code");
            dgvGrades.Columns.Add("CurrentGrade", "Current Grade");

            // Editable column for the new grade
            DataGridViewTextBoxColumn newGradeCol = new DataGridViewTextBoxColumn
            {
                Name = "NewGrade",
                HeaderText = "New Grade"
            };
            dgvGrades.Columns.Add(newGradeCol);

            // Save button column
            DataGridViewButtonColumn saveCol = new DataGridViewButtonColumn
            {
                Name = "Save",
                HeaderText = "",
                Text = "Save",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            saveCol.DefaultCellStyle.BackColor = Color.FromArgb(33, 33, 33);
            saveCol.DefaultCellStyle.ForeColor = Color.White;
            saveCol.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            saveCol.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 33, 33);
            saveCol.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvGrades.Columns.Add(saveCol);

            dgvGrades.Columns["StudentId"].Width = 95;
            dgvGrades.Columns["StudentName"].Width = 130;
            dgvGrades.Columns["Subject"].Width = 130;
            dgvGrades.Columns["Code"].Width = 80;
            dgvGrades.Columns["CurrentGrade"].Width = 90;
            dgvGrades.Columns["NewGrade"].Width = 90;
            dgvGrades.Columns["Save"].Width = 60;

            // Make most columns read-only, only "NewGrade" editable
            foreach (DataGridViewColumn col in dgvGrades.Columns)
                col.ReadOnly = (col.Name != "NewGrade");
        }

        private void LoadGrades()
        {
            // Remove old empty-state if any
            var existing = pnlGrades.Controls.Find("lblEmptyGrades", false);
            foreach (var c in existing) pnlGrades.Controls.Remove(c);

            // TODO: replace with SQL query later
            dgvGrades.Rows.Clear();

            if (dgvGrades.Rows.Count == 0)
                ShowEmptyGradesMessage();

            dgvGrades.ClearSelection();
            dgvGrades.CurrentCell = null;
        }

        private void ShowEmptyGradesMessage()
        {
            dgvGrades.Visible = false;

            Label lblEmpty = new Label
            {
                Name = "lblEmptyGrades",
                Text = "Search for a student to encode grades",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(20, 20),
                Size = new Size(675, 455),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlGrades.Controls.Add(lblEmpty);
        }

        private void LoadRecentChanges()
        {
            // TODO: replace with SQL query later
            pnlChangesList.Controls.Clear();

            int changeCount = 0;
            if (changeCount == 0)
                ShowEmptyChangesMessage();
        }

        private void ShowEmptyChangesMessage()
        {
            Label lblEmpty = new Label
            {
                Text = "No recent changes",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(0, 0),
                Size = new Size(180, 445),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(245, 243, 248)
            };
            pnlChangesList.Controls.Add(lblEmpty);
        }

        // ===== Event handlers =====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            string placeholder = "Search students by ID or name...";

            if (string.IsNullOrWhiteSpace(query) || query == placeholder)
            {
                MessageBox.Show("Please enter a student ID or name to search.",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: query MySQL students table
            MessageBox.Show($"Will load grades for student matching: \"{query}\"",
                "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only respond to clicks on the Save button column
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvGrades.Columns[e.ColumnIndex].Name != "Save") return;

            string studentId = dgvGrades.Rows[e.RowIndex].Cells["StudentId"].Value?.ToString();
            string subjectCode = dgvGrades.Rows[e.RowIndex].Cells["Code"].Value?.ToString();
            string newGrade = dgvGrades.Rows[e.RowIndex].Cells["NewGrade"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(newGrade))
            {
                MessageBox.Show("Please enter a new grade before saving.",
                    "Missing Grade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: UPDATE grades SET grade = ? WHERE student_id = ? AND subject_code = ?;
            // Also INSERT into audit_logs the change
            MessageBox.Show($"Saved grade {newGrade} for student {studentId} in {subjectCode}.",
                "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Sidebar nav =====
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            frmAdminDashboard f = new frmAdminDashboard();
            f.Show();
            this.Close();
        }

        private void btnNavStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Students page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavEncodeGrades_Click(object sender, EventArgs e)
        {
            // already here
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