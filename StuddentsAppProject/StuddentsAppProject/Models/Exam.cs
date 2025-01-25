using System.ComponentModel.DataAnnotations;

namespace StuddentsAppProject.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Display(Name = "Student")]
        [Required]
        public int StudentId { get; set; }
                
        public Student? Student { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public int SubjectId { get; set; }

        public Subject? Subject { get; set; }

        [Display(Name = "Date of exam")]
        [Required]
        public DateTime DateOfExam { get; set; }

        [Display(Name = "Mark")]
        [Required]
        [Range(5, 10)]
        public int ExamMark { get; set; }
    }
}
