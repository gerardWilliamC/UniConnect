namespace UniConnect.Models
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Program { get; set; }
        public int YearLevel { get; set; }
        public string Semester { get; set; }

        // Empty constructor (used when reading from DB row by row)
        public Student() { }

        // Full constructor (used when creating a new Student object in code)
        public Student(string studentId, string fullName, string email,
                       string program, int yearLevel, string semester)
        {
            StudentId = studentId;
            FullName = fullName;
            Email = email;
            Program = program;
            YearLevel = yearLevel;
            Semester = semester;
        }
    }
}