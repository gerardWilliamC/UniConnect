using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

namespace UniConnect
{
    public partial class frmMyGrades : Form
    {
        private List<Grade> _currentGrades = new List<Grade>();
        private List<string> _semesters = new List<string>();
        private string _selectedSemester = null;
        private List<Button> _semesterTabs = new List<Button>();

        public frmMyGrades()
        {
            InitializeComponent();
        }

        private void frmMyGrades_Load(object sender, EventArgs e)
        {
            LoadLogo();

            if (Session.CurrentStudent == null)
            {
                MessageBox.Show("Session expired. Please log in again.",
                    "Not signed in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new frmStudentLogin().Show();
                this.Close();
                return;
            }

            Student me = Session.CurrentStudent;
            DatabaseHelper db = new DatabaseHelper();

            try
            {
                lblUserName.Text = me.FullName;
                lblUserId.Text = me.StudentId;
                lblSemPill.Text = me.Semester;

                // Build semester tabs from the student's actual grade history
                _semesters = db.GetStudentSemesters(me.StudentId);
                _selectedSemester = me.Semester;        // default to current
                BuildSemesterTabs();

                StyleGradesGrid();
                RefreshAll(db, me);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load grades.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        // =====================================================================
        // SEMESTER TABS  (replaces the single btnSemFilter)
        // =====================================================================

        private void BuildSemesterTabs()
        {
            pnlFilterRow.Controls.Clear();
            _semesterTabs.Clear();

            // Enable auto-scroll so tabs that don't fit can be scrolled to
            pnlFilterRow.AutoScroll = true;

            if (_semesters.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "No grade history yet",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = new Point(0, 15),
                    Size = new Size(300, 25)
                };
                pnlFilterRow.Controls.Add(lbl);
                return;
            }

            // Make sure _selectedSemester is one that actually exists.
            // If the student's current Session.Semester isn't in their grade history
            // (e.g., grades not encoded yet), fall back to the newest one available.
            if (!_semesters.Contains(_selectedSemester))
                _selectedSemester = _semesters[0];

            int x = 0;
            foreach (string sem in _semesters)
            {
                Button tab = new Button
                {
                    Text = sem,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Location = new Point(x, 8),
                    Size = new Size(190, 36),
                    Tag = sem
                };
                tab.FlatAppearance.BorderSize = 0;
                StyleTab(tab, isActive: sem == _selectedSemester);
                tab.Click += SemesterTab_Click;

                pnlFilterRow.Controls.Add(tab);
                _semesterTabs.Add(tab);
                x += 200;   // 190 width + 10 gap
            }
        }
        private void StyleTab(Button tab, bool isActive)
        {
            if (isActive)
            {
                tab.BackColor = Color.FromArgb(123, 31, 49);
                tab.ForeColor = Color.White;
            }
            else
            {
                tab.BackColor = Color.White;
                tab.ForeColor = Color.FromArgb(117, 117, 117);
            }
        }

        private void SemesterTab_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            if (clicked == null) return;

            _selectedSemester = clicked.Tag.ToString();

            // Update active state on all tabs
            foreach (var tab in _semesterTabs)
                StyleTab(tab, isActive: tab.Tag.ToString() == _selectedSemester);

            // Reload data for the new semester
            RefreshAll(new DatabaseHelper(), Session.CurrentStudent);
        }

        // =====================================================================
        // REFRESH (called on load + every semester switch)
        // =====================================================================

        private void RefreshAll(DatabaseHelper db, Student me)
        {
            RefreshStatCards(db, me);
            RefreshGradesTable(db, me);
        }

        private void RefreshStatCards(DatabaseHelper db, Student me)
        {
            decimal? gwa = db.GetStudentGWA(me.StudentId, _selectedSemester);
            if (gwa.HasValue)
            {
                lblGwaValue.Text = gwa.Value.ToString("0.00");
                lblGwaSub.Text = "Selected semester";
            }
            else
            {
                lblGwaValue.Text = "—";
                lblGwaSub.Text = "No grades yet";
            }

            var (totalUnits, passedCount, failedCount) =
                db.GetGradesSummary(me.StudentId, _selectedSemester);

            lblUnitsValue.Text = totalUnits > 0 ? totalUnits.ToString() : "—";
            lblUnitsSub.Text = "Total this semester";

            lblPassedValue.Text = passedCount.ToString();
            lblPassedSub.Text = passedCount == 1 ? "Subject passed" : "Subjects passed";

            lblFailedValue.Text = failedCount.ToString();
            lblFailedSub.Text = failedCount == 1 ? "Subject failed" : "Subjects failed";
        }

        // =====================================================================
        // GRADES TABLE
        // =====================================================================

        private void StyleGradesGrid()
        {
            dgvGrades.EnableHeadersVisualStyles = false;
            dgvGrades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(123, 31, 49);
            dgvGrades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvGrades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGrades.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(123, 31, 49);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvGrades.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvGrades.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvGrades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 232, 237);
            dgvGrades.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 33, 33);
            dgvGrades.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvGrades.GridColor = Color.FromArgb(230, 230, 230);
            dgvGrades.RowsDefaultCellStyle.BackColor = Color.White;
            dgvGrades.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            dgvGrades.Columns.Clear();
            dgvGrades.Columns.Add("SubjectCode", "Subject Code");
            dgvGrades.Columns.Add("SubjectName", "Subject Name");
            dgvGrades.Columns.Add("Units", "Units");
            dgvGrades.Columns.Add("Instructor", "Instructor");
            dgvGrades.Columns.Add("Grade", "Grade");
            dgvGrades.Columns.Add("Status", "Status");

            dgvGrades.Columns["SubjectCode"].Width = 100;
            dgvGrades.Columns["SubjectName"].Width = 240;
            dgvGrades.Columns["Units"].Width = 60;
            dgvGrades.Columns["Instructor"].Width = 160;
            dgvGrades.Columns["Grade"].Width = 70;
            dgvGrades.Columns["Status"].Width = 80;
        }

        private void RefreshGradesTable(DatabaseHelper db, Student me)
        {
            foreach (var c in pnlGrades.Controls.Find("lblEmptyGrades", false))
                pnlGrades.Controls.Remove(c);

            _currentGrades = db.GetStudentGrades(me.StudentId, _selectedSemester);
            dgvGrades.Rows.Clear();

            foreach (var g in _currentGrades)
            {
                string gradeText = g.GradeValue.HasValue
                    ? g.GradeValue.Value.ToString("0.00")
                    : "—";

                int rowIndex = dgvGrades.Rows.Add(
                    g.SubjectCode, g.SubjectName, g.Units,
                    g.Instructor, gradeText, g.Status);

                var statusCell = dgvGrades.Rows[rowIndex].Cells["Status"];
                if (g.Status == "Passed")
                    statusCell.Style.ForeColor = Color.FromArgb(34, 139, 34);
                else if (g.Status == "Failed")
                    statusCell.Style.ForeColor = Color.FromArgb(220, 38, 38);
                else
                    statusCell.Style.ForeColor = Color.FromArgb(217, 119, 6);
            }

            lblPagination.Text = _currentGrades.Count == 0
                ? "No grades to show"
                : $"Showing {_currentGrades.Count} of {_currentGrades.Count} subjects";

            if (_currentGrades.Count == 0)
                ShowEmptyGradesMessage();
            else
                dgvGrades.Visible = true;

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
                Location = dgvGrades.Location,
                Size = dgvGrades.Size,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlGrades.Controls.Add(lblEmpty);
        }

        // =====================================================================
        // BUTTONS
        // =====================================================================

        // The old btnSemFilter handler is no longer wired in the designer
        // (the button is hidden behind the dynamic tabs), but the method must
        // still exist because Designer.cs references it.
        private void btnSemFilter_Click(object sender, EventArgs e)
        {
            // No-op — replaced by semester tabs above
        }

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {
            if (_currentGrades.Count == 0)
            {
                MessageBox.Show("There are no grades to download yet.",
                    "No data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV file (*.csv)|*.csv";
                dlg.FileName = $"GradeReport_{Session.CurrentStudent.StudentId}_{_selectedSemester.Replace(" ", "_").Replace("—", "-").Replace("/", "-")}.csv";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var writer = new System.IO.StreamWriter(dlg.FileName))
                    {
                        writer.WriteLine("Subject Code,Subject Name,Units,Instructor,Grade,Status,Semester");
                        foreach (var g in _currentGrades)
                        {
                            string gradeText = g.GradeValue.HasValue
                                ? g.GradeValue.Value.ToString("0.00")
                                : "";

                            writer.WriteLine(
                                $"\"{g.SubjectCode}\"," +
                                $"\"{g.SubjectName}\"," +
                                $"{g.Units}," +
                                $"\"{g.Instructor}\"," +
                                $"{gradeText}," +
                                $"\"{g.Status}\"," +
                                $"\"{g.Semester}\"");
                        }
                    }

                    MessageBox.Show("Grade report saved successfully.",
                        "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not save the file.\n\n" + ex.Message,
                        "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =====================================================================
        // SIDEBAR NAV
        // =====================================================================

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            new frmStudentDashboard().Show();
            this.Close();
        }

        private void btnNavGrades_Click(object sender, EventArgs e) { /* already here */ }

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
            new frmAnnouncements().Show();
            this.Close();
        }

        private void btnNavProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Profile page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}