using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

namespace UniConnect
{
    public partial class frmPostAnnouncement : Form
    {
        // The full posted list from the DB; the panel filters this in-memory on search
        private List<Announcement> _allPosted = new List<Announcement>();

        // Track which posted card is currently selected (for Archive button context)
        private int _selectedAnnouncementId = -1;

        // Placeholders (older .NET doesn't have native PlaceholderText)
        private const string TITLE_PLACEHOLDER = "  Enter announcement title…";
        private const string CONTENT_PLACEHOLDER = "  Write the announcement body here…";
        private const string SEARCH_PLACEHOLDER = "  Search posted announcements…";
        private bool _titlePlaceholderShown = true;
        private bool _contentPlaceholderShown = true;
        private bool _searchPlaceholderShown = true;

        public frmPostAnnouncement()
        {
            InitializeComponent();
        }

        private void frmPostAnnouncement_Load(object sender, EventArgs e)
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

            SetupAudienceDropdown();
            SetupPlaceholders();

            // Wire up the post / archive / cancel buttons
            btnPost.Click -= btnPost_Click;
            btnPost.Click += btnPost_Click;
            btnArchive.Click -= btnArchive_Click;
            btnArchive.Click += btnArchive_Click;
            btnCancel.Click -= btnCancel_Click;
            btnCancel.Click += btnCancel_Click;
            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            RefreshPostedList();
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        // =====================================================================
        // FORM SETUP
        // =====================================================================

        private void SetupAudienceDropdown()
        {
            cmbAudience.Items.Clear();
            cmbAudience.Items.AddRange(new object[] { "All", "Students", "Faculty" });
            cmbAudience.DropDownStyle = ComboBoxStyle.DropDownList;   // prevent free typing
            cmbAudience.SelectedIndex = 0;   // default to "All"
        }

        private void SetupPlaceholders()
        {
            // ----- Title -----
            txtTitle.Text = TITLE_PLACEHOLDER;
            txtTitle.ForeColor = Color.FromArgb(160, 160, 160);
            _titlePlaceholderShown = true;
            txtTitle.GotFocus += (s, e) =>
            {
                if (_titlePlaceholderShown)
                {
                    txtTitle.Text = "";
                    txtTitle.ForeColor = Color.FromArgb(33, 33, 33);
                    _titlePlaceholderShown = false;
                }
            };
            txtTitle.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    txtTitle.Text = TITLE_PLACEHOLDER;
                    txtTitle.ForeColor = Color.FromArgb(160, 160, 160);
                    _titlePlaceholderShown = true;
                }
            };

            // ----- Content -----
            txtContent.Text = CONTENT_PLACEHOLDER;
            txtContent.ForeColor = Color.FromArgb(160, 160, 160);
            _contentPlaceholderShown = true;
            txtContent.GotFocus += (s, e) =>
            {
                if (_contentPlaceholderShown)
                {
                    txtContent.Text = "";
                    txtContent.ForeColor = Color.FromArgb(33, 33, 33);
                    _contentPlaceholderShown = false;
                }
            };
            txtContent.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtContent.Text))
                {
                    txtContent.Text = CONTENT_PLACEHOLDER;
                    txtContent.ForeColor = Color.FromArgb(160, 160, 160);
                    _contentPlaceholderShown = true;
                }
            };

            // ----- Search -----
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

        // =====================================================================
        // POST
        // =====================================================================

        private void btnPost_Click(object sender, EventArgs e)
        {
            // Pull cleaned input (skip placeholders)
            string title = _titlePlaceholderShown ? "" : (txtTitle.Text ?? "").Trim();
            string content = _contentPlaceholderShown ? "" : (txtContent.Text ?? "").Trim();
            string audience = cmbAudience.SelectedItem?.ToString() ?? "All";

            // Validate
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a title for the announcement.",
                    "Missing title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (title.Length > 200)
            {
                MessageBox.Show("Title is too long (max 200 characters).",
                    "Title too long", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Please enter the announcement content.",
                    "Missing content", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContent.Focus();
                return;
            }

            // Confirm
            string confirm = $"Post this announcement?\n\n" +
                             $"Title:    {title}\n" +
                             $"Audience: {audience}\n\n" +
                             $"It will be visible immediately to the target audience.";

            if (MessageBox.Show(confirm, "Confirm post",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Save (transactional: announcement + audit log)
            DatabaseHelper db = new DatabaseHelper();
            try
            {
                int newId = db.PostAnnouncementWithAudit(
                    title: title,
                    content: content,
                    targetAudience: audience,
                    adminId: Session.CurrentAdmin.AdminId);

                MessageBox.Show($"Announcement posted (#{newId}).",
                    "Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshPostedList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not post announcement.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtTitle.Text = TITLE_PLACEHOLDER;
            txtTitle.ForeColor = Color.FromArgb(160, 160, 160);
            _titlePlaceholderShown = true;

            txtContent.Text = CONTENT_PLACEHOLDER;
            txtContent.ForeColor = Color.FromArgb(160, 160, 160);
            _contentPlaceholderShown = true;

            cmbAudience.SelectedIndex = 0;
        }

        // =====================================================================
        // ARCHIVE
        // =====================================================================

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (_selectedAnnouncementId == -1)
            {
                MessageBox.Show("Select an announcement from the right panel first to archive it.",
                    "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ann = _allPosted.FirstOrDefault(a => a.AnnouncementId == _selectedAnnouncementId);
            if (ann == null) return;

            if (ann.IsArchived)
            {
                MessageBox.Show("That announcement is already archived.",
                    "Already archived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string confirm = $"Archive this announcement?\n\n" +
                             $"\"{ann.Title}\"\n\n" +
                             $"It will no longer be shown to students or faculty.";

            if (MessageBox.Show(confirm, "Confirm archive",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            DatabaseHelper db = new DatabaseHelper();
            try
            {
                db.ArchiveAnnouncementWithAudit(
                    _selectedAnnouncementId,
                    Session.CurrentAdmin.AdminId,
                    ann.Title);

                MessageBox.Show("Announcement archived.",
                    "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selectedAnnouncementId = -1;
                RefreshPostedList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not archive announcement.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // CANCEL  (clears the form, confirms if there's unsaved content)
        // =====================================================================

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool hasInput =
                (!_titlePlaceholderShown && !string.IsNullOrWhiteSpace(txtTitle.Text)) ||
                (!_contentPlaceholderShown && !string.IsNullOrWhiteSpace(txtContent.Text));

            if (hasInput)
            {
                if (MessageBox.Show("Discard the current draft?",
                        "Confirm cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        != DialogResult.Yes)
                    return;
            }

            ClearForm();
        }

        // =====================================================================
        // SEARCH
        // =====================================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = _searchPlaceholderShown ? "" : (txtSearch.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(query))
            {
                RenderPostedList(_allPosted);
                return;
            }

            var matches = _allPosted
                .Where(a =>
                    (a.Title != null && a.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (a.Content != null && a.Content.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            RenderPostedList(matches);

            if (matches.Count == 0)
            {
                MessageBox.Show($"No posted announcements match \"{query}\".",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =====================================================================
        // POSTED ANNOUNCEMENTS SIDEBAR
        // =====================================================================

        private void RefreshPostedList()
        {
            DatabaseHelper db = new DatabaseHelper();
            try
            {
                _allPosted = db.GetAllAnnouncementsForAdmin(limit: 50);
            }
            catch
            {
                _allPosted = new List<Announcement>();
            }

            RenderPostedList(_allPosted);
        }

        private void RenderPostedList(List<Announcement> items)
        {
            pnlPostedList.SuspendLayout();
            pnlPostedList.Controls.Clear();
            pnlPostedList.AutoScroll = false;
            pnlPostedList.VerticalScroll.Value = 0;

            if (items.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "No announcements posted yet",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(160, 160, 160),
                    Location = new Point(0, 0),
                    Size = pnlPostedList.Size,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                pnlPostedList.Controls.Add(lbl);
                pnlPostedList.ResumeLayout();
                return;
            }

            int y = 0;
            int itemWidth = pnlPostedList.Width - 25;

            foreach (var a in items)
            {
                Panel card = BuildPostedItem(a, y, itemWidth);
                pnlPostedList.Controls.Add(card);
                y += card.Height + 8;
            }

            pnlPostedList.AutoScroll = true;
            pnlPostedList.ResumeLayout();
        }

        private Panel BuildPostedItem(Announcement a, int y, int width)
        {
            bool isSelected = (a.AnnouncementId == _selectedAnnouncementId);

            Panel card = new Panel
            {
                BackColor = isSelected
                    ? Color.FromArgb(252, 232, 237)
                    : Color.White,
                Location = new Point(2, y),
                Size = new Size(width, 92),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand,
                Tag = a.AnnouncementId
            };
            card.Click += PostedItem_Click;

            // Left accent
            Color accentColor = a.IsArchived
                ? Color.FromArgb(160, 160, 160)
                : Color.FromArgb(123, 31, 49);

            Panel accent = new Panel
            {
                BackColor = accentColor,
                Location = new Point(0, 0),
                Size = new Size(4, 92)
            };
            card.Controls.Add(accent);

            // ARCHIVED badge (if applicable)
            int titleX = 12;
            if (a.IsArchived)
            {
                var lblArchived = new Label
                {
                    Text = "ARCHIVED",
                    Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                    BackColor = Color.FromArgb(160, 160, 160),
                    ForeColor = Color.White,
                    Location = new Point(12, 8),
                    Size = new Size(70, 16),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                card.Controls.Add(lblArchived);
                titleX = 90;
            }

            var lblTitle = new Label
            {
                Text = a.Title,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = a.IsArchived
                    ? Color.FromArgb(120, 120, 120)
                    : Color.FromArgb(123, 31, 49),
                Location = new Point(titleX, 6),
                Size = new Size(width - titleX - 8, 20),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblTitle);

            var lblBody = new Label
            {
                Text = a.Content,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(12, 30),
                Size = new Size(width - 20, 30),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblBody);

            string footer = $"{a.TargetAudience}  •  {a.PostedAt:MMM d, yyyy}  •  {a.PostedByName ?? "—"}";
            var lblFooter = new Label
            {
                Text = footer,
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(12, 65),
                Size = new Size(width - 20, 16),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblFooter);

            // Make every child clickable too so clicks anywhere on the card register
            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.Click += (s, e) => PostedItem_Click(card, EventArgs.Empty);
            }

            return card;
        }

        private void PostedItem_Click(object sender, EventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null) return;

            int id = (int)card.Tag;

            // Toggle: clicking the already-selected card deselects it
            _selectedAnnouncementId = (_selectedAnnouncementId == id) ? -1 : id;

            // Re-render to update the highlight
            RenderPostedList(_allPosted);
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
            new frmEncodeGrades().Show();
            this.Close();
        }

        private void btnNavEnrollments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Enrollments — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavPostAnnouncement_Click(object sender, EventArgs e)
        {
            // Already on Post Announcement
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