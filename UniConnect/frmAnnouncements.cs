using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

namespace UniConnect
{
    public partial class frmAnnouncements : Form
    {
        private List<Announcement> _allAnnouncements = new List<Announcement>();
        private int _expandedAnnouncementId = -1;   // -1 means none expanded

        public frmAnnouncements()
        {
            InitializeComponent();
        }

        private void frmAnnouncements_Load(object sender, EventArgs e)
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

            try
            {
                lblUserName.Text = me.FullName;
                lblUserId.Text = me.StudentId;
                lblSemPill.Text = me.Semester;

                RefreshAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load announcements.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLogo()
        {
            pbSidebarLogo.Image = Properties.Resources.l2lm;
            pbWatermark.Image = Properties.Resources.l1lm;
        }

        // =====================================================================
        // REFRESH (re-queries DB and re-renders everything)
        // =====================================================================
        private void RefreshAll()
        {
            DatabaseHelper db = new DatabaseHelper();
            string myId = Session.CurrentStudent.StudentId;

            // Unread count
            int unread = db.GetUnreadAnnouncementCount(myId, "Students");
            lblUnreadCount.Text = unread.ToString();

            // Full list (with per-announcement read state)
            _allAnnouncements = db.GetAnnouncements(
                "Students", limit: 100, studentId: myId);

            RenderAnnouncementList(_allAnnouncements);
        }

        // =====================================================================
        // RENDER LIST
        // =====================================================================
        private void RenderAnnouncementList(List<Announcement> items)
        {
            pnlLatestList.SuspendLayout();
            pnlLatestList.Controls.Clear();
            pnlLatestList.AutoScroll = false;          // turn off scroll first
            pnlLatestList.VerticalScroll.Value = 0;     // reset position
            pnlLatestList.HorizontalScroll.Value = 0;

            if (items.Count == 0)
            {
                ShowEmptyState();
                pnlLatestList.ResumeLayout();
                return;
            }

            int y = 0;
            int cardWidth = pnlLatestList.Width - 25;

            foreach (var a in items)
            {
                bool isExpanded = (a.AnnouncementId == _expandedAnnouncementId);
                Panel card = BuildAnnouncementCard(a, y, cardWidth, isExpanded);
                pnlLatestList.Controls.Add(card);
                y += card.Height + 12;
            }

            pnlLatestList.AutoScroll = true;            // re-enable after content is set
            pnlLatestList.ResumeLayout();
        }

        private Panel BuildAnnouncementCard(Announcement a, int y, int cardWidth, bool isExpanded)
        {
            // Use Label.AutoSize logic via TextRenderer for accurate height measurement
            Font bodyFont = new Font("Segoe UI", 9F);
            int bodyMaxWidth = cardWidth - 30;

            // Measure full body text height
            Size fullBodySize = TextRenderer.MeasureText(
                a.Content,
                bodyFont,
                new Size(bodyMaxWidth, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);

            int bodyHeight = isExpanded ? fullBodySize.Height + 6 : 40;

            // Total card height: badges/title area (72px) + body + footer area (35px)
            int cardHeight = 72 + bodyHeight + 35;
            if (!isExpanded) cardHeight = 140;   // fixed collapsed height

            Panel card = new Panel
            {
                BackColor = Color.White,
                Location = new Point(5, y),
                Size = new Size(cardWidth, cardHeight),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand,
                Tag = a.AnnouncementId
            };
            card.Click += Card_Click;

            // Left accent strip
            var accent = new Panel
            {
                BackColor = a.IsRead
                    ? Color.FromArgb(220, 220, 220)
                    : Color.FromArgb(123, 31, 49),
                Location = new Point(0, 0),
                Size = new Size(4, cardHeight)
            };
            card.Controls.Add(accent);

            // Tag badges row
            int badgeX = 15;
            int badgeY = 12;

            bool isNew = !a.IsRead && (DateTime.Now - a.PostedAt).TotalDays <= 7;
            if (isNew)
            {
                var badgeNew = MakeBadge("NEW",
                    bg: Color.FromArgb(123, 31, 49),
                    fg: Color.White);
                badgeNew.Location = new Point(badgeX, badgeY);
                card.Controls.Add(badgeNew);
                badgeX += badgeNew.Width + 8;
            }

            var (audBg, audFg) = AudienceColors(a.TargetAudience);
            var badgeAud = MakeBadge(a.TargetAudience, bg: audBg, fg: audFg);
            badgeAud.Location = new Point(badgeX, badgeY);
            card.Controls.Add(badgeAud);

            var lblDate = new Label
            {
                Text = a.PostedAt.ToString("MMMM d, yyyy"),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(cardWidth - 130, badgeY + 4),
                Size = new Size(120, 18),
                TextAlign = ContentAlignment.MiddleRight
            };
            card.Controls.Add(lblDate);

            var lblTitle = new Label
            {
                Text = a.Title,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = a.IsRead
                    ? Color.FromArgb(60, 60, 60)
                    : Color.FromArgb(123, 31, 49),
                Location = new Point(15, 42),
                Size = new Size(cardWidth - 30, 26),
                AutoEllipsis = true
            };
            card.Controls.Add(lblTitle);

            // Body — exact height for expanded, fixed 40 for collapsed
            var lblBody = new Label
            {
                Text = a.Content,
                Font = bodyFont,
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(15, 72),
                Size = new Size(bodyMaxWidth, bodyHeight),
                AutoEllipsis = !isExpanded,
                AutoSize = false
            };
            card.Controls.Add(lblBody);

            // Footer always sits at fixed position from bottom
            string postedByText = string.IsNullOrEmpty(a.PostedByName)
                ? "Posted by: Administrator"
                : "Posted by: " + a.PostedByName;
            var lblFooter = new Label
            {
                Text = postedByText + (isExpanded ? "    •    Click to collapse" : "    •    Click to read more"),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(15, cardHeight - 25),
                Size = new Size(cardWidth - 30, 18)
            };
            card.Controls.Add(lblFooter);

            // Make children clickable too
            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.Click += (s, e) => Card_Click(card, EventArgs.Empty);
            }

            return card;
        }

        // =====================================================================
        // CLICK HANDLER — expand/collapse + mark as read
        // =====================================================================
        private void Card_Click(object sender, EventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null) return;

            int announcementId = (int)card.Tag;
            DatabaseHelper db = new DatabaseHelper();
            string myId = Session.CurrentStudent.StudentId;

            // Toggle expand/collapse
            if (_expandedAnnouncementId == announcementId)
            {
                // Was expanded → collapse it
                _expandedAnnouncementId = -1;
            }
            else
            {
                // Was collapsed (or another was open) → expand this one + mark as read
                _expandedAnnouncementId = announcementId;

                var ann = _allAnnouncements.FirstOrDefault(x => x.AnnouncementId == announcementId);
                if (ann != null && !ann.IsRead)
                {
                    try
                    {
                        db.MarkAnnouncementAsRead(myId, announcementId);
                        ann.IsRead = true;

                        // Update the unread count in the sidebar
                        int unread = db.GetUnreadAnnouncementCount(myId, "Students");
                        lblUnreadCount.Text = unread.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not mark as read.\n\n" + ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Re-render with the new expanded state
            RenderAnnouncementList(_allAnnouncements);
        }

        // =====================================================================
        // SMALL HELPERS
        // =====================================================================
        private Label MakeBadge(string text, Color bg, Color fg)
        {
            int width = 14 + (text.Length * 7);
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BackColor = bg,
                ForeColor = fg,
                Size = new Size(width, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };
        }

        private (Color bg, Color fg) AudienceColors(string audience)
        {
            switch ((audience ?? "").ToLower())
            {
                case "students":
                    return (Color.FromArgb(252, 232, 237), Color.FromArgb(123, 31, 49));
                case "faculty":
                    return (Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175));
                case "all":
                default:
                    return (Color.FromArgb(220, 252, 231), Color.FromArgb(22, 101, 52));
            }
        }

        private void ShowEmptyState()
        {
            var lbl = new Label
            {
                Text = "No announcements yet",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 160, 160),
                Location = new Point(0, 0),
                Size = pnlLatestList.Size,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            pnlLatestList.Controls.Add(lbl);
        }

        // =====================================================================
        // SEARCH
        // =====================================================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = (txtSearch.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(query))
            {
                RenderAnnouncementList(_allAnnouncements);
                return;
            }

            var matches = _allAnnouncements
                .Where(a =>
                    (a.Title != null && a.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (a.Content != null && a.Content.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0))
                .ToList();

            RenderAnnouncementList(matches);

            if (matches.Count == 0)
            {
                MessageBox.Show($"No announcements match \"{query}\".",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnNavGrades_Click(object sender, EventArgs e)
        {
            new frmMyGrades().Show();
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

        private void btnNavAnnouncements_Click(object sender, EventArgs e) { /* already here */ }

        private void btnNavProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Profile page — not part of this build phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}