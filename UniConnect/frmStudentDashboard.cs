using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

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

            // If somehow no one is logged in, kick back to login
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
                // Sidebar — student name and ID
                lblUserName.Text = me.FullName;
                lblUserId.Text = me.StudentId;

                // Top bar — semester pill
                lblSemPill.Text = me.Semester;

                // Update Heading to Notifications
                lblAnnTitle.Text = "Notifications";

                // GWA stat card
                decimal? gwa = db.GetStudentGWA(me.StudentId, me.Semester);
                if (gwa.HasValue)
                {
                    lblGwaValue.Text = gwa.Value.ToString("0.00");
                    lblGwaSub.Text = "This semester";
                }
                else
                {
                    lblGwaValue.Text = "—";
                    lblGwaSub.Text = "No grades yet";
                }

                // Enrolled Units stat card
                int units = db.GetEnrolledUnits(me.StudentId, me.Semester);
                if (units > 0)
                {
                    lblUnitsValue.Text = units.ToString();
                    lblUnitsSub.Text = "This semester";
                }
                else
                {
                    lblUnitsValue.Text = "—";
                    lblUnitsSub.Text = "Not enrolled";
                }

                // Year Level stat card
                if (me.YearLevel > 0)
                {
                    lblYearValue.Text = me.YearLevel.ToString();
                    lblYearSub.Text = me.Program ?? "";
                }
                else
                {
                    lblYearValue.Text = "—";
                    lblYearSub.Text = "No data yet";
                }

                // Grades preview (top 5)
                StyleGradesPreviewGrid();
                LoadGradesPreview(db, me);

                // Unified Notifications (Announcements + Grade Updates)
                LoadNotifications(db, me);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load dashboard data.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        private void StyleGradesPreviewGrid()
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
            dgvGrades.Columns.Add("SubjectCode", "Code");
            dgvGrades.Columns.Add("SubjectName", "Subject");
            dgvGrades.Columns.Add("Grade", "Grade");
            dgvGrades.Columns.Add("Status", "Status");

            dgvGrades.Columns["SubjectCode"].Width = 70;
            dgvGrades.Columns["SubjectName"].Width = 320;
            dgvGrades.Columns["Grade"].Width = 70;
            dgvGrades.Columns["Status"].Width = 90;
        }

        private void LoadGradesPreview(DatabaseHelper db, Student me)
        {
            foreach (var c in pnlGrades.Controls.Find("lblEmptyGradesPreview", false))
                pnlGrades.Controls.Remove(c);

            dgvGrades.Rows.Clear();

            List<Grade> grades = db.GetStudentGrades(me.StudentId, me.Semester);

            int rowsToShow = Math.Min(grades.Count, 5);
            for (int i = 0; i < rowsToShow; i++)
            {
                Grade g = grades[i];
                string gradeText = g.GradeValue.HasValue ? g.GradeValue.Value.ToString("0.00") : "—";
                dgvGrades.Rows.Add(g.SubjectCode, g.SubjectName, gradeText, g.Status);
            }

            if (grades.Count == 0)
            {
                dgvGrades.Visible = false;
                var lbl = new Label
                {
                    Name = "lblEmptyGradesPreview",
                    Text = "No grades available to view",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = dgvGrades.Location,
                    Size = dgvGrades.Size,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White
                };
                pnlGrades.Controls.Add(lbl);
            }
            else
            {
                dgvGrades.Visible = true;
            }

            dgvGrades.ClearSelection();
            dgvGrades.CurrentCell = null;
        }

        // =====================================================================
        // UNIFIED NOTIFICATIONS LOGIC
        // =====================================================================

        private void LoadNotifications(DatabaseHelper db, Student me)
        {
            pnlAnnList.Controls.Clear();
            var notifications = new List<NotificationItem>();

            // 1. Fetch Announcements
            var announcements = db.GetAnnouncements("Students", limit: 5, studentId: me.StudentId);
            foreach (var a in announcements)
            {
                notifications.Add(new NotificationItem
                {
                    Title = a.Title,
                    Type = "Announcement",
                    Timestamp = a.PostedAt,
                    Content = a.Content
                });
            }

            // 2. Fetch Grade Updates
            var grades = db.GetStudentGrades(me.StudentId, me.Semester);
            foreach (var g in grades)
            {
                // Only add to feed if a grade value has actually been encoded
                if (g.GradeValue.HasValue)
                {
                    notifications.Add(new NotificationItem
                    {
                        Title = $"Grade Updated: {g.SubjectCode}",
                        Type = "Grade Update",
                        Timestamp = g.UpdatedAt,
                        Content = $"New Status: {g.Status}"
                    });
                }
            }

            // 3. Combine and Sort by Newest First
            var sortedFeed = notifications.OrderByDescending(n => n.Timestamp).Take(5).ToList();

            if (sortedFeed.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "No recent notifications",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = new Point(0, 0),
                    Size = pnlAnnList.Size,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlAnnList.Controls.Add(lbl);
                return;
            }

            // 4. Render to UI
            int y = 0;
            foreach (var item in sortedFeed)
            {
                Panel card = BuildNotificationCard(item, y);
                pnlAnnList.Controls.Add(card);
                y += 80;
            }
        }

        private Panel BuildNotificationCard(NotificationItem item, int y)
        {
            var card = new Panel
            {
                BackColor = Color.White,
                Location = new Point(0, y),
                Size = new Size(pnlAnnList.Width - 5, 75),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand, // Visual cue for interactivity
                Tag = item // Store data for the click handler
            };

            card.Click += NotificationCard_Click; // Register click event

            // Colors match the web portal logic
            Color typeColor = item.Type == "Grade Update"
                ? Color.FromArgb(16, 185, 129) // Green
                : Color.FromArgb(139, 21, 56); // Brand Primary Red

            var lblTitle = new Label
            {
                Text = item.Title,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = typeColor,
                Location = new Point(5, 4),
                Size = new Size(card.Width - 10, 20),
                AutoEllipsis = true
            };

            var lblMeta = new Label
            {
                Text = $"{item.Type} • {item.Timestamp:MMM d, yyyy}",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(5, 26),
                Size = new Size(card.Width - 10, 14)
            };

            var lblBody = new Label
            {
                Text = item.Content,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(5, 44),
                Size = new Size(card.Width - 10, 28),
                AutoEllipsis = true
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblMeta);
            card.Controls.Add(lblBody);

            // Ensure clicking the text also triggers the card click
            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.Click += (s, e) => NotificationCard_Click(card, EventArgs.Empty);
            }

            return card;
        }

        // =====================================================================
        // NEW CLICK HANDLER - NAVIGATION LOGIC
        // =====================================================================

        private void NotificationCard_Click(object sender, EventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null || card.Tag == null) return;

            NotificationItem item = (NotificationItem)card.Tag;

            if (item.Type == "Grade Update")
            {
                btnNavGrades_Click(null, null); // Redirect to My Grades tab
            }
            else if (item.Type == "Announcement")
            {
                btnNavAnnouncements_Click(null, null); // Redirect to Announcements tab
            }
        }

        // ===== Sidebar nav events =====
        private void btnNavDashboard_Click(object sender, EventArgs e) { }

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PerformLogout();
            }
        }

        private void PerformLogout()
        {
            Session.Clear();
            new frmStudentLogin().Show();
            this.Close();
        }
    }

    // Helper class for unified feed
    public class NotificationItem
    {
        public string Title { get; set; }
        public string Type { get; set; } // "Announcement" or "Grade Update"
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
    }
}