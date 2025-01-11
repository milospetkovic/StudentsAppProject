namespace StuddentsAppProject.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTime DateOfExam { get; set; }
        public int ExamMark { get; set; }
    }
}
