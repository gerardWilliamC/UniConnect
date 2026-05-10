using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniConnect
{
    public partial class frmPostAnnouncement : Form
    {
        public frmPostAnnouncement()
        {
            InitializeComponent();
        }

        private void frmPostAnnouncement_Load(object sender, EventArgs e)
        {
            LoadLogo();
            cmbAudience.SelectedIndex = 0;   // Default to "All"
            LoadPostedAnnouncements();
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        private void LoadPostedAnnouncements()
        {
            // TODO: replace with SQL query later
            pnlPostedList.Controls.Clear();

            int postedCount = 0;
            if (postedCount == 0)
                ShowEmptyPostedMessage();
        }

        private void ShowEmptyPostedMessage()
        {
            Label lblEmpty = new Label
            {
                Text = "No announcements posted yet",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(0, 0),
                Size = new Size(180, 445),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(245, 243, 248)
            };
            pnlPostedList.Controls.Add(lblEmpty);
        }

        // ===== Form actions =====
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a search term.",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: filter posted announcements by title/content LIKE %query%
            MessageBox.Show($"Will filter posted announcements matching: \"{query}\"",
                "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string audience = cmbAudience.SelectedItem?.ToString() ?? "All";
            string content = txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Please fill in both Title and Content before posting.",
                    "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: INSERT INTO announcements (title, audience, content, posted_by, posted_at) ...
            // Also INSERT into audit_logs the announcement event
            MessageBox.Show(
                $"Announcement posted to: {audience}\n\nTitle: {title}",
                "Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form for the next entry
            ClearForm();
            LoadPostedAnnouncements();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            // TODO: open the archived announcements view, or archive the currently-selected one
            MessageBox.Show("Will open the archived announcements view.",
                "Archive", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) && string.IsNullOrWhiteSpace(txtContent.Text))
            {
                ClearForm();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Discard the current announcement?",
                "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                ClearForm();
        }

        private void ClearForm()
        {
            txtTitle.Text = "";
            txtContent.Text = "";
            cmbAudience.SelectedIndex = 0;
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
            // already here
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