namespace UniConnect.Models
{
    public class Subject
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Units { get; set; }
        public string Instructor { get; set; }

        public Subject() { }
    }
}