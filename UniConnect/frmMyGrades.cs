using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UniConnect
{
    public partial class frmMyGrades : Form
    {
        public frmMyGrades()
        {
            InitializeComponent();
        }

        private void frmMyGrades_Load(object sender, EventArgs e)
        {
            LoadLogo();
            StyleGradesGrid();
            LoadGrades();         // empty for now
            ResetStatCards();     // dashes when no data
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "Resources", "L1 - Light Mode.png");
                if (File.Exists(logoPath))
                {
                    pbSidebarLogo.Image = Image.FromFile(logoPath);
                    pbWatermark.Image = Image.FromFile(logoPath);
                }
                // Force the watermark to inherit the lavender main background
                pbWatermark.BackColor = System.Drawing.Color.FromArgb(245, 243, 248);
                pbWatermark.Parent = pnlMain;
                pbWatermark.BringToFront();
            }
            catch { }
        }

        private void StyleGradesGrid()
        {
            // Header style — same red as Dashboard
            dgvGrades.EnableHeadersVisualStyles = false;
            dgvGrades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(123, 31, 49);
            dgvGrades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvGrades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGrades.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(123, 31, 49);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Row style
            dgvGrades.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvGrades.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvGrades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 232, 237);
            dgvGrades.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 33, 33);
            dgvGrades.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvGrades.GridColor = Color.FromArgb(230, 230, 230);
            dgvGrades.RowsDefaultCellStyle.BackColor = Color.White;
            dgvGrades.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            // Build columns — full grade report has more columns than the dashboard preview
            dgvGrades.Columns.Clear();
            dgvGrades.Columns.Add("SubjectCode", "Subject Code");
            dgvGrades.Columns.Add("SubjectName", "Subject Name");
            dgvGrades.Columns.Add("Units", "Units");
            dgvGrades.Columns.Add("Instructor", "Instructor");
            dgvGrades.Columns.Add("Grade", "Grade");
            dgvGrades.Columns.Add("Status", "Status");

            dgvGrades.Columns["SubjectCode"].Width = 110;
            dgvGrades.Columns["SubjectName"].Width = 240;
            dgvGrades.Columns["Units"].Width = 70;
            dgvGrades.Columns["Instructor"].Width = 200;
            dgvGrades.Columns["Grade"].Width = 90;
            dgvGrades.Columns["Status"].Width = 130;
        }

        private void LoadGrades()
        {
            // Remove any old empty-state label so we don't stack them
            var existing = pnlGrades.Controls.Find("lblEmptyGrades", false);
            foreach (var c in existing) pnlGrades.Controls.Remove(c);

            // TODO: replace with SQL query later
            dgvGrades.Rows.Clear();

            if (dgvGrades.Rows.Count == 0)
            {
                ShowEmptyGradesMessage();
            }
            else
            {
                dgvGrades.Visible = true;
            }

            UpdatePaginationLabel(dgvGrades.Rows.Count);

            dgvGrades.ClearSelection();
            dgvGrades.CurrentCell = null;
        }

        private void ShowEmptyGradesMessage()
        {
            dgvGrades.Visible = false;

            Label lblEmpty = new Label
            {
                Name = "lblEmptyGrades",
                Text = "No grades available to view",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(0, 0),
                Size = new Size(770, 305),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlGrades.Controls.Add(lblEmpty);
            lblEmpty.SendToBack();   // sit BEHIND the grid + button, not on top
        }

        private void UpdatePaginationLabel(int rowCount)
        {
            lblPagination.Text = $"Page 1 of 1   •   Showing {rowCount} subjects";
        }

        private void ResetStatCards()
        {
            lblGwaValue.Text = "—";
            lblGwaSub.Text = "No data yet";

            lblUnitsValue.Text = "—";
            lblUnitsSub.Text = "No data yet";

            lblPassedValue.Text = "—";
            lblPassedSub.Text = "No data yet";

            lblFailedValue.Text = "—";
            lblFailedSub.Text = "No data yet";
        }

        // ===== Sidebar nav events =====
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            frmStudentDashboard f = new frmStudentDashboard();
            f.Show();
            this.Close();
        }

        private void btnNavGrades_Click(object sender, EventArgs e)
        {
            // Already on My Grades
        }

        private void btnNavSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Schedule page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavEnrollments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enrollments page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavAnnouncements_Click(object sender, EventArgs e)
        {
            frmAnnouncements f = new frmAnnouncements();
            f.Show();
            this.Close();
        }

        private void btnNavProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Profile page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== Page actions =====
        private void btnSemFilter_Click(object sender, EventArgs e)
        {
            // TODO: open semester picker / dropdown to filter grades by semester
            MessageBox.Show("Semester filter — will let you switch between semesters.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {
            // TODO: generate and save PDF/printout of the grade report
            MessageBox.Show("This will generate a downloadable grade report.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}