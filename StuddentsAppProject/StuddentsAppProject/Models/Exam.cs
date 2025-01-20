using System.ComponentModel.DataAnnotations;

namespace StuddentsAppProject.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
                
        public Student Student { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public DateTime DateOfExam { get; set; }

        [Required]
        [Range(5, 10)]
        public int ExamMark { get; set; }
    }
}
