using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

namespace UniConnect
{
    public partial class frmEncodeGrades : Form
    {
        // =====================================================================
        // STATE MANAGEMENT
        // =====================================================================

        // The student currently selected (or null if no search yet)
        private Student _currentStudent = null;

        // Cache of the grades currently shown — used for filtering and update detection
        private List<Grade> _currentGrades = new List<Grade>();

        // Search placeholder constants for older .NET versions
        private const string SEARCH_PLACEHOLDER = "  Search by student ID or name…";
        private bool _searchPlaceholderShown = true;

        public frmEncodeGrades()
        {
            InitializeComponent();
        }

        private void frmEncodeGrades_Load(object sender, EventArgs e)
        {
            LoadLogo();

            // Authentication Guard
            if (Session.CurrentAdmin == null)
            {
                MessageBox.Show("Session expired. Please log in again.",
                    "Not signed in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new frmAdminLogin().Show();
                this.Close();
                return;
            }

            Admin me = Session.CurrentAdmin;

            // Sidebar & Top Bar Setup
            lblUserName.Text = me.FullName;
            lblUserId.Text = me.AdminId;
            lblAdminPill.Text = me.Role ?? "Admin";

            // Component Initialization
            SetupSearchPlaceholder();
            StyleGradesGrid();
            ShowSearchPrompt();

            // Initial sidebar refresh
            RefreshRecentChanges();
        }

        private void LoadLogo()
        {
            //
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        // =====================================================================
        // SEARCH & FILTERING LOGIC (Mirrors Web Portal)
        // =====================================================================

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = SEARCH_PLACEHOLDER;
            txtSearch.ForeColor = Color.FromArgb(160, 160, 160);
            _searchPlaceholderShown = true;

            txtSearch.GotFocus += (s, e) =>
            {
                if (_searchPlaceholderShown)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.FromArgb(33, 33, 33);
                    _searchPlaceholderShown = false;
                }
            };

            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = SEARCH_PLACEHOLDER;
                    txtSearch.ForeColor = Color.FromArgb(160, 160, 160);
                    _searchPlaceholderShown = true;
                }
            };

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch_Click(s, e);
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_searchPlaceholderShown || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a student ID or name to search.",
                    "Empty search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = txtSearch.Text.Trim();
            DatabaseHelper db = new DatabaseHelper();

            try
            {
                _currentStudent = db.FindStudent(query); //

                if (_currentStudent != null)
                {
                    // Populate Header Details (Mirroring student-info-header on web)
                    lblStudentNameHeader.Text = _currentStudent.FullName;
                    lblStudentIdHeader.Text = $"ID: {_currentStudent.StudentId} | {_currentStudent.Program}";
                    pnlStudentInfo.Visible = true;

                    // Fetch all grades for this student to enable filtering
                    _currentGrades = db.GetStudentGrades(_currentStudent.StudentId); //

                    // Populate dynamic Year Filter (Extract years from semester strings like "AY 2025-2026")
                    var years = _currentGrades
                        .Select(g => g.Semester.Split(' ').Last())
                        .Distinct()
                        .OrderByDescending(y => y)
                        .ToList();

                    cmbYearFilter.Items.Clear();
                    cmbYearFilter.Items.Add("All Years");
                    foreach (var year in years) cmbYearFilter.Items.Add(year);

                    cmbYearFilter.SelectedIndex = 0;
                    cmbSemFilter.SelectedIndex = 0; // Default to "All Semesters"

                    RenderGradesTable();
                }
                else
                {
                    pnlStudentInfo.Visible = false;
                    MessageBox.Show($"No student found matching \"{query}\".",
                        "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ShowSearchPrompt();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            // Re-render the grid whenever a dropdown value changes
            RenderGradesTable();
        }

        // =====================================================================
        // GRADES TABLE RENDERING & STYLING
        // =====================================================================

        private void StyleGradesGrid()
        {
            dgvGrades.EnableHeadersVisualStyles = false;
            dgvGrades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(123, 31, 49);
            dgvGrades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvGrades.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(123, 31, 49);

            dgvGrades.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvGrades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 232, 237);
            dgvGrades.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 33, 33);
            dgvGrades.GridColor = Color.FromArgb(230, 230, 230);
            dgvGrades.RowTemplate.Height = 42;

            dgvGrades.Columns.Clear();

            // Read-only info columns
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Code", HeaderText = "Code", Width = 65, ReadOnly = true });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subject", HeaderText = "Subject", Width = 210, ReadOnly = true });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Units", HeaderText = "Units", Width = 45, ReadOnly = true });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Current", HeaderText = "Current", Width = 60, ReadOnly = true });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", Width = 75, ReadOnly = true });

            // 1. "New Grade" Input Column (Styled to look like a Textbox)
            var colNew = new DataGridViewTextBoxColumn { Name = "NewGrade", HeaderText = "New Grade", Width = 85 };
            colNew.DefaultCellStyle.BackColor = Color.White;
            colNew.DefaultCellStyle.Padding = new Padding(5);
            dgvGrades.Columns.Add(colNew);

            // 2. Action Column - SAVE (Always visible, matching web portal side)
            var colSave = new DataGridViewButtonColumn
            {
                Name = "SaveBtn",
                HeaderText = "Actions", // Label on top
                Text = "Save",
                UseColumnTextForButtonValue = true,
                Width = 65,
                FlatStyle = FlatStyle.Flat
            };
            colSave.DefaultCellStyle.BackColor = Color.FromArgb(33, 33, 33);
            colSave.DefaultCellStyle.ForeColor = Color.White;
            dgvGrades.Columns.Add(colSave);

            // 3. Action Column - REMOVE (Sets back to Pending)
            var colRemove = new DataGridViewButtonColumn
            {
                Name = "RemoveBtn",
                HeaderText = "",
                Text = "Remove",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            colRemove.DefaultCellStyle.BackColor = Color.White;
            colRemove.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
            dgvGrades.Columns.Add(colRemove);

            // Hook the cell-click handler
            dgvGrades.CellContentClick -= dgvGrades_CellContentClick;
            dgvGrades.CellContentClick += dgvGrades_CellContentClick;
        }

        private void RenderGradesTable()
        {
            RemoveSearchPrompt();
            dgvGrades.Rows.Clear();
            dgvGrades.Visible = true;

            string selYear = cmbYearFilter.SelectedItem?.ToString();
            string selSem = cmbSemFilter.SelectedItem?.ToString();

            // Filtering logic matching web portal's renderGradesTable()
            var filtered = _currentGrades.Where(g => {
                bool yearMatch = selYear == "All Years" || g.Semester.Contains(selYear);
                bool semMatch = selSem == "All Semesters" || g.Semester.StartsWith(selSem);
                return yearMatch && semMatch;
            }).ToList();

            if (filtered.Count == 0)
            {
                ShowSearchPrompt("No enrolled subjects match the selected filters.");
                return;
            }

            foreach (var g in filtered)
            {
                int rowIndex = dgvGrades.Rows.Add(
                    g.SubjectCode,
                    g.SubjectName,
                    g.Units,
                    g.GradeValue.HasValue ? g.GradeValue.Value.ToString("0.00") : "—",
                    g.Status,
                    "",
                    "Save",
                    "Remove"
                );

                // Dynamic Status Coloring
                var statusCell = dgvGrades.Rows[rowIndex].Cells["Status"];
                if (g.Status == "Passed") statusCell.Style.ForeColor = Color.FromArgb(34, 139, 34);
                else if (g.Status == "Failed") statusCell.Style.ForeColor = Color.FromArgb(220, 38, 38);
                else statusCell.Style.ForeColor = Color.FromArgb(217, 119, 6);
            }

            dgvGrades.ClearSelection();
        }

        // =====================================================================
        // BUTTON ACTIONS: SAVE & REMOVE (Mirrors PHP API logic)
        // =====================================================================

        private void dgvGrades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string colName = dgvGrades.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = dgvGrades.Rows[e.RowIndex];

            string code = row.Cells["Code"].Value.ToString();
            Grade target = _currentGrades.First(g => g.SubjectCode == code);

            DatabaseHelper db = new DatabaseHelper();
            string adminId = Session.CurrentAdmin.AdminId;

            // --- HANDLE SAVE ---
            if (colName == "SaveBtn")
            {
                string input = (row.Cells["NewGrade"].Value ?? "").ToString().Trim();
                if (decimal.TryParse(input, out decimal newGrade) && newGrade >= 1.0m && newGrade <= 5.0m)
                {
                    string status = newGrade <= 3.0m ? "Passed" : "Failed";
                    string log = $"Updated {target.SubjectCode} for {target.StudentId}: {target.GradeValue ?? 0} -> {newGrade}";

                    db.UpdateGradeWithAudit(target.StudentId, target.SubjectCode, newGrade, status, target.Semester, adminId, log); //
                    MessageBox.Show("Grade saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSearch_Click(null, null); // Refresh list
                }
                else { MessageBox.Show("Enter a valid grade (1.00 to 5.00).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }

            // --- HANDLE REMOVE (Set to Pending) ---
            if (colName == "RemoveBtn")
            {
                if (MessageBox.Show($"Remove grade for {target.SubjectCode}? This will set it to Pending.", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string log = $"Removed grade for {target.SubjectCode} for {target.StudentId} (Was: {target.GradeValue})";
                    db.UpdateGradeWithAudit(target.StudentId, target.SubjectCode, null, "Pending", target.Semester, adminId, log); //
                    MessageBox.Show("Grade removed and set to Pending.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSearch_Click(null, null); // Refresh list
                }
            }
        }

        // =====================================================================
        // SIDEBAR RECENT CHANGES & NAVIGATION
        // =====================================================================

        private void RefreshRecentChanges()
        {
            DatabaseHelper db = new DatabaseHelper();
            pnlChangesList.Controls.Clear();
            pnlChangesList.AutoScroll = false;
            pnlChangesList.VerticalScroll.Value = 0;

            var logs = db.GetRecentGradeAuditLogs(limit: 10); //

            if (!logs.Any())
            {
                var lblEmpty = new Label { Text = "No recent changes", ForeColor = Color.Gray, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                pnlChangesList.Controls.Add(lblEmpty);
                return;
            }

            int y = 0;
            foreach (var log in logs)
            {
                Panel item = BuildChangeItem(log, y, pnlChangesList.Width - 5);
                pnlChangesList.Controls.Add(item);
                y += item.Height + 6;
            }

            pnlChangesList.AutoScroll = true;
        }

        private Panel BuildChangeItem(AuditLog log, int y, int width)
        {
            Panel p = new Panel { Location = new Point(0, y), Size = new Size(width, 58), BackColor = Color.Transparent };
            p.Controls.Add(new Panel { BackColor = Color.FromArgb(34, 139, 34), Location = new Point(0, 8), Size = new Size(4, 42) });
            p.Controls.Add(new Label { Text = log.ActionType, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), Location = new Point(10, 4), Size = new Size(width - 15, 16) });
            p.Controls.Add(new Label { Text = log.Details, Font = new Font("Segoe UI", 7.5F), Location = new Point(10, 21), Size = new Size(width - 15, 22), AutoEllipsis = true });
            p.Controls.Add(new Label { Text = $"{log.PerformedByName} • {HumanizeTimeAgo(log.Timestamp)}", Font = new Font("Segoe UI", 7.5F), ForeColor = Color.Gray, Location = new Point(10, 42), Size = new Size(width - 15, 14) });
            return p;
        }

        private string HumanizeTimeAgo(DateTime when)
        {
            TimeSpan diff = DateTime.Now - when;
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes}m ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours}h ago";
            return when.ToString("MMM d");
        }

        private void ShowSearchPrompt(string msg = null)
        {
            foreach (var c in pnlGrades.Controls.Find("lblPrompt", false)) pnlGrades.Controls.Remove(c);
            dgvGrades.Visible = false;
            Label lbl = new Label { Name = "lblPrompt", Text = msg ?? "Search for a student to view and edit their grades", Font = new Font("Segoe UI", 10F), ForeColor = Color.Gray, Location = dgvGrades.Location, Size = dgvGrades.Size, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.White };
            pnlGrades.Controls.Add(lbl);
        }

        private void RemoveSearchPrompt() { foreach (var c in pnlGrades.Controls.Find("lblPrompt", false)) pnlGrades.Controls.Remove(c); }

        // =====================================================================
        // NAVIGATION & LOGOUT
        // =====================================================================

        private void btnNavDashboard_Click(object sender, EventArgs e) { new frmAdminDashboard().Show(); this.Close(); }
        private void btnNavStudents_Click(object sender, EventArgs e) { MessageBox.Show("Manage Students module coming soon."); }
        private void btnNavEncodeGrades_Click(object sender, EventArgs e) { /* Already here */ }
        private void btnNavEnrollments_Click(object sender, EventArgs e) { MessageBox.Show("Manage Enrollments module coming soon."); }
        private void btnNavPostAnnouncement_Click(object sender, EventArgs e) { new frmPostAnnouncement().Show(); this.Close(); }
        private void btnNavReports_Click(object sender, EventArgs e) { MessageBox.Show("Reports module coming soon."); }
        private void btnNavAuditLogs_Click(object sender, EventArgs e) { MessageBox.Show("Full Audit Logs module coming soon."); }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PerformLogout();
        }

        private void PerformLogout()
        {
            Session.Clear(); //
            new frmAdminLogin().Show();
            this.Close();
        }
    }
}