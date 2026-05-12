namespace UniConnect.Models
{
    public class AuditLog
    {
        public int LogId { get; set; }
        public string ActionType { get; set; }
        public string TableAffected { get; set; }
        public string PerformedBy { get; set; }     // admin_id
        public string PerformedByName { get; set; } // joined from admins.full_name
        public string Details { get; set; }
        public System.DateTime Timestamp { get; set; }

        public AuditLog() { }
    }
}