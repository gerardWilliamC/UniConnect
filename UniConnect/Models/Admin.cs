namespace UniConnect.Models
{
    public class Admin
    {
        public string AdminId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public Admin() { }

        public Admin(string adminId, string fullName, string email, string role)
        {
            AdminId = adminId;
            FullName = fullName;
            Email = email;
            Role = role;
        }
    }
}