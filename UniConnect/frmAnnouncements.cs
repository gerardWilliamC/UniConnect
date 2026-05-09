using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UniConnect
{
    public partial class frmAnnouncements : Form
    {
        public frmAnnouncements()
        {
            InitializeComponent();
        }

        private void frmAnnouncements_Load(object sender, EventArgs e)
        {
            LoadLogo();
            LoadAnnouncements();
            UpdateUnreadCount();
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
            }
            catch { }
        }

        private void LoadAnnouncements()
        {
            // TODO: replace with SQL query later
            pnlLatestList.Controls.Clear();

            int announcementCount = 0; // SQL: count of returned rows

            if (announcementCount == 0)
                ShowEmptyAnnouncementsMessage();
        }

        private void ShowEmptyAnnouncementsMessage()
        {
            Label lblEmpty = new Label
            {
                Name = "lblEmptyAnn",
                Text = "No recent announcements",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(0, 0),
                Size = new Size(635, 495),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlLatestList.Controls.Add(lblEmpty);
        }

        private void UpdateUnreadCount()
        {
            // TODO: replace with SQL query later — COUNT(*) from announcements WHERE is_read=0
            int unreadCount = 0;
            lblUnreadCount.Text = unreadCount.ToString();
        }

        // ===== Sidebar nav =====
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            frmStudentDashboard f = new frmStudentDashboard();
            f.Show();
            this.Close();
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
            // Already on Announcements
        }

        private void btnNavProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Profile page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a search term.",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: filter announcements by SQL WHERE title LIKE %query% OR body LIKE %query%
            MessageBox.Show($"Search will filter announcements matching: \"{query}\"",
                "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}