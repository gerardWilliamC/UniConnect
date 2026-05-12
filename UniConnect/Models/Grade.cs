namespace UniConnect.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }    // joined from subjects
        public int Units { get; set; }              // joined from subjects
        public string Instructor { get; set; }      // joined from subjects
        public decimal? GradeValue { get; set; }    // nullable: a grade may not be encoded yet
        public string Status { get; set; }          // Passed / Failed / Pending
        public string Semester { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Grade() { }
    }
}