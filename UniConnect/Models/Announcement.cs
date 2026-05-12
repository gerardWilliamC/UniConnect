namespace UniConnect.Models
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string TargetAudience { get; set; }
        public string PostedBy { get; set; }       // admin_id
        public string PostedByName { get; set; }   // joined from admins.full_name
        public System.DateTime PostedAt { get; set; }
        public bool IsArchived { get; set; }
        public bool IsRead { get; set; }

        public Announcement() { }
    }
}