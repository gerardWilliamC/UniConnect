using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

namespace UniConnect
{
    public partial class frmEncodeGrades : Form
    {
        // The student currently selected (or null if no search yet)
        private Student _currentStudent = null;

        // Cache of the grades currently shown — used to detect what changed when saving
        private List<Grade> _currentGrades = new List<Grade>();

        // Search placeholder text behavior (since our .NET version doesn't have PlaceholderText)
        private const string SEARCH_PLACEHOLDER = "  Search by student ID or name…";
        private bool _searchPlaceholderShown = true;

        public frmEncodeGrades()
        {
            InitializeComponent();
        }

        private void frmEncodeGrades_Load(object sender, EventArgs e)
        {
            LoadLogo();

            if (Session.CurrentAdmin == null)
            {
                MessageBox.Show("Session expired. Please log in again.",
                    "Not signed in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new frmAdminLogin().Show();
                this.Close();
                return;
            }

            Admin me = Session.CurrentAdmin;

            lblUserName.Text = me.FullName;
            lblUserId.Text = me.AdminId;
            lblAdminPill.Text = me.Role ?? "Admin";

            // Search box placeholder
            SetupSearchPlaceholder();

            // Empty grid until a student is searched
            StyleGradesGrid();
            ShowSearchPrompt();

            // Recent changes sidebar
            RefreshRecentChanges();
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        // =====================================================================
        // SEARCH BOX (manual placeholder — older .NET doesn't have PlaceholderText)
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

            // Allow pressing Enter inside the search box to trigger search
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
                _currentStudent = db.FindStudent(query);

                if (_currentStudent == null)
                {
                    MessageBox.Show($"No student found matching \"{query}\".",
                        "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _currentGrades.Clear();
                    ShowSearchPrompt();
                    return;
                }

                LoadStudentGrades(db);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            // Read-only info columns
            var colCode = new DataGridViewTextBoxColumn { Name = "SubjectCode", HeaderText = "Code", Width = 70, ReadOnly = true };
            var colName = new DataGridViewTextBoxColumn { Name = "SubjectName", HeaderText = "Subject", Width = 220, ReadOnly = true };
            var colUnits = new DataGridViewTextBoxColumn { Name = "Units", HeaderText = "Units", Width = 50, ReadOnly = true };
            var colCurrent = new DataGridViewTextBoxColumn { Name = "CurrentGrade", HeaderText = "Current", Width = 70, ReadOnly = true };
            var colStatus = new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", Width = 70, ReadOnly = true };

            // Editable input column
            var colNew = new DataGridViewTextBoxColumn
            {
                Name = "NewGrade",
                HeaderText = "New Grade",
                Width = 90,
                ReadOnly = false
            };
            colNew.DefaultCellStyle.BackColor = Color.FromArgb(252, 232, 237);
            colNew.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // Per-row "Save" button
            var colSave = new DataGridViewButtonColumn
            {
                Name = "SaveBtn",
                HeaderText = "",
                Text = "Save",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            colSave.DefaultCellStyle.BackColor = Color.FromArgb(33, 33, 33);
            colSave.DefaultCellStyle.ForeColor = Color.White;
            colSave.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 33, 33);
            colSave.DefaultCellStyle.SelectionForeColor = Color.White;
            colSave.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);

            dgvGrades.Columns.AddRange(colCode, colName, colUnits, colCurrent, colStatus, colNew, colSave);

            // Hook the cell-click handler ONCE
            dgvGrades.CellClick -= dgvGrades_CellClick;
            dgvGrades.CellClick += dgvGrades_CellClick;
        }

        private void LoadStudentGrades(DatabaseHelper db)
        {
            RemoveSearchPrompt();
            dgvGrades.Visible = true;
            dgvGrades.Rows.Clear();

            // Load this student's grades (all semesters — admin needs to see the whole picture)
            _currentGrades = db.GetStudentGrades(_currentStudent.StudentId);

            if (_currentGrades.Count == 0)
            {
                ShowSearchPrompt($"{_currentStudent.FullName} has no grade records yet.");
                return;
            }

            foreach (var g in _currentGrades)
            {
                string currentGradeText = g.GradeValue.HasValue
                    ? g.GradeValue.Value.ToString("0.00")
                    : "—";

                int rowIndex = dgvGrades.Rows.Add(
                    g.SubjectCode,
                    g.SubjectName,
                    g.Units,
                    currentGradeText,
                    g.Status,
                    "",                 // empty editable column
                    "Save");

                // Color-code the Status column
                var statusCell = dgvGrades.Rows[rowIndex].Cells["Status"];
                if (g.Status == "Passed")
                    statusCell.Style.ForeColor = Color.FromArgb(34, 139, 34);
                else if (g.Status == "Failed")
                    statusCell.Style.ForeColor = Color.FromArgb(220, 38, 38);
                else
                    statusCell.Style.ForeColor = Color.FromArgb(217, 119, 6);
            }

            dgvGrades.ClearSelection();
            dgvGrades.CurrentCell = null;
        }

        private void ShowSearchPrompt(string customMessage = null)
        {
            // Remove any existing prompt label
            foreach (var c in pnlGrades.Controls.Find("lblPrompt", false))
                pnlGrades.Controls.Remove(c);

            dgvGrades.Visible = false;

            Label lbl = new Label
            {
                Name = "lblPrompt",
                Text = customMessage ??
                    "Search for a student to view and edit their grades",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = dgvGrades.Location,
                Size = dgvGrades.Size,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlGrades.Controls.Add(lbl);
        }

        private void RemoveSearchPrompt()
        {
            foreach (var c in pnlGrades.Controls.Find("lblPrompt", false))
                pnlGrades.Controls.Remove(c);
        }

        // =====================================================================
        // SAVE A SINGLE ROW
        // =====================================================================

        private void dgvGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvGrades.Columns[e.ColumnIndex].Name != "SaveBtn") return;
            if (_currentStudent == null) return;

            DataGridViewRow row = dgvGrades.Rows[e.RowIndex];
            Grade target = _currentGrades[e.RowIndex];   // matches by index since they're built in order

            string newGradeRaw = (row.Cells["NewGrade"].Value ?? "").ToString().Trim();

            if (string.IsNullOrWhiteSpace(newGradeRaw))
            {
                MessageBox.Show("Enter a new grade in the highlighted cell first.",
                    "No grade entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Parse + validate
            if (!decimal.TryParse(newGradeRaw, out decimal newGrade))
            {
                MessageBox.Show("That's not a valid number. Use Philippine grading like 1.00, 1.25, 2.50, etc.",
                    "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newGrade < 1.00m || newGrade > 5.00m)
            {
                MessageBox.Show("Grade must be between 1.00 and 5.00 (Philippine grading scale).",
                    "Out of range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Derive status from grade (3.00 and below = Passed)
            string newStatus = newGrade <= 3.00m ? "Passed" : "Failed";

            // Confirm
            string confirm = $"Change {target.SubjectCode} ({target.SubjectName}) " +
                             $"for {_currentStudent.FullName}?\n\n" +
                             $"Current grade: {(target.GradeValue.HasValue ? target.GradeValue.Value.ToString("0.00") : "—")} ({target.Status})\n" +
                             $"New grade:     {newGrade:0.00} ({newStatus})";

            if (MessageBox.Show(confirm, "Confirm change",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Build the audit log details message
            string oldGradeText = target.GradeValue.HasValue
                ? target.GradeValue.Value.ToString("0.00")
                : "no grade";
            string details = $"Updated {target.SubjectCode} for {_currentStudent.StudentId} ({_currentStudent.FullName}): " +
                             $"{oldGradeText} → {newGrade:0.00} ({newStatus})";

            // Save (transactional: grade + audit log together)
            DatabaseHelper db = new DatabaseHelper();
            try
            {
                db.UpdateGradeWithAudit(
                    studentId: _currentStudent.StudentId,
                    subjectCode: target.SubjectCode,
                    newGrade: newGrade,
                    newStatus: newStatus,
                    semester: target.Semester,
                    adminId: Session.CurrentAdmin.AdminId,
                    detailsForLog: details);

                // Update the row in-place so the UI reflects the new state
                row.Cells["CurrentGrade"].Value = newGrade.ToString("0.00");
                row.Cells["Status"].Value = newStatus;
                row.Cells["NewGrade"].Value = "";

                var statusCell = row.Cells["Status"];
                statusCell.Style.ForeColor = newStatus == "Passed"
                    ? Color.FromArgb(34, 139, 34)
                    : Color.FromArgb(220, 38, 38);

                // Update our in-memory cache too so subsequent saves compare against the new value
                target.GradeValue = newGrade;
                target.Status = newStatus;

                // Refresh sidebar
                RefreshRecentChanges();

                MessageBox.Show("Grade updated and logged.",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save grade.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // RECENT CHANGES SIDEBAR
        // =====================================================================

        private void RefreshRecentChanges()
        {
            DatabaseHelper db = new DatabaseHelper();
            pnlChangesList.Controls.Clear();
            pnlChangesList.AutoScroll = false;
            pnlChangesList.VerticalScroll.Value = 0;

            List<AuditLog> logs;
            try
            {
                logs = db.GetRecentGradeAuditLogs(limit: 10);
            }
            catch
            {
                logs = new List<AuditLog>();
            }

            if (logs.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "No recent changes",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = new Point(0, 0),
                    Size = pnlChangesList.Size,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                pnlChangesList.Controls.Add(lblEmpty);
                return;
            }

            int y = 0;
            int itemWidth = pnlChangesList.Width - 5;

            foreach (var log in logs)
            {
                Panel item = BuildChangeItem(log, y, itemWidth);
                pnlChangesList.Controls.Add(item);
                y += item.Height + 6;
            }

            pnlChangesList.AutoScroll = true;
        }

        private Panel BuildChangeItem(AuditLog log, int y, int width)
        {
            Panel item = new Panel
            {
                BackColor = Color.Transparent,
                Location = new Point(0, y),
                Size = new Size(width, 58),
                BorderStyle = BorderStyle.None
            };

            // Green left dot
            Panel dot = new Panel
            {
                BackColor = Color.FromArgb(34, 139, 34),
                Location = new Point(0, 8),
                Size = new Size(4, 42)
            };
            item.Controls.Add(dot);

            var lblAction = new Label
            {
                Text = log.ActionType ?? "Grade Updated",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33),
                Location = new Point(10, 4),
                Size = new Size(width - 15, 16),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblAction);

            var lblDetails = new Label
            {
                Text = log.Details ?? "",
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(10, 21),
                Size = new Size(width - 15, 22),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblDetails);

            string footer = (log.PerformedByName ?? log.PerformedBy ?? "—")
                + "  •  " + HumanizeTimeAgo(log.Timestamp);
            var lblFooter = new Label
            {
                Text = footer,
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(10, 42),
                Size = new Size(width - 15, 14),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            item.Controls.Add(lblFooter);

            return item;
        }

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
            new frmAdminDashboard().Show();
            this.Close();
        }

        private void btnNavStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Students — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavEncodeGrades_Click(object sender, EventArgs e)
        {
            // Already on Encode Grades
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