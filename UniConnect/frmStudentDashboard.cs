using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UniConnect
{
    public partial class frmStudentDashboard : Form
    {
        public frmStudentDashboard()
        {
            InitializeComponent();
        }

        private void frmStudentDashboard_Load(object sender, EventArgs e)
        {
            LoadLogo();
            StyleGradesGrid();
            LoadGrades();          // empty for now
            LoadAnnouncements();   // empty for now
            ResetStatCards();      // show dashes when no data
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
                    pbWatermark.BringToFront();
                }
                else
                {
                    // Helpful for debugging — tells you exactly where it expected the file
                    MessageBox.Show(
                        $"Logo file not found at:\n{logoPath}\n\n" +
                        "Make sure 'logo.png' is in the project's Resources folder " +
                        "and its 'Copy to Output Directory' property is set to 'Copy if newer'.",
                        "Logo not loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logo: " + ex.Message,
                    "Logo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGradesGrid()
        {
            // Header style
            dgvGrades.EnableHeadersVisualStyles = false;
            dgvGrades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(139, 21, 56);
            dgvGrades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvGrades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGrades.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(139, 21, 56);
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

            // Build columns
            dgvGrades.Columns.Clear();
            dgvGrades.Columns.Add("SubjectCode", "Subject Code");
            dgvGrades.Columns.Add("SubjectName", "Subject Name");
            dgvGrades.Columns.Add("Units", "Units");
            dgvGrades.Columns.Add("Grade", "Grade");
            dgvGrades.Columns.Add("Semester", "Semester");

            dgvGrades.Columns["SubjectCode"].Width = 100;
            dgvGrades.Columns["SubjectName"].Width = 190;
            dgvGrades.Columns["Units"].Width = 60;
            dgvGrades.Columns["Grade"].Width = 70;
            dgvGrades.Columns["Semester"].Width = 100;
        }

        private void LoadGrades()
        {
            // TODO: replace with SQL query later
            dgvGrades.Rows.Clear();

            if (dgvGrades.Rows.Count == 0)
                ShowEmptyGradesMessage();

            // Clear any default selection so the blue/highlighted cell goes away
            dgvGrades.ClearSelection();
            dgvGrades.CurrentCell = null;
        }

        private void ShowEmptyGradesMessage()
        {
            // Hide the grid entirely and show a centered "no data" label inside the panel
            dgvGrades.Visible = false;

            Label lblEmpty = new Label
            {
                Name = "lblEmptyGrades",
                Text = "No grades available to view",
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(20, 55),
                Size = new Size(530, 340),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlGrades.Controls.Add(lblEmpty);
        }

        private void LoadAnnouncements()
        {
            // TODO: replace with SQL query later
            pnlAnnList.Controls.Clear();

            if (pnlAnnList.Controls.Count == 0)
                ShowEmptyAnnouncementsMessage();
        }

        private void ShowEmptyAnnouncementsMessage()
        {
            Label lblEmpty = new Label
            {
                Text = "No recent announcements",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(0, 0),
                Size = new Size(255, 160),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlAnnList.Controls.Add(lblEmpty);
        }

        private void ResetStatCards()
        {
            // Show dashes since there's no data yet
            lblGwaValue.Text = "—";
            lblGwaSub.Text = "No data yet";

            lblUnitsValue.Text = "—";
            lblUnitsSub.Text = "No data yet";

            lblYearValue.Text = "—";
            lblYearSub.Text = "No data yet";
        }

        // ===== Sidebar nav events =====
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            // Already on Dashboard
        }

        private void btnNavGrades_Click(object sender, EventArgs e)
        {
            frmMyGrades f = new frmMyGrades();
            f.Show();
            this.Close();
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

        private void btnViewFullGrades_Click(object sender, EventArgs e)
        {
            frmMyGrades f = new frmMyGrades();
            f.Show();
            this.Close();
        }
    }
}