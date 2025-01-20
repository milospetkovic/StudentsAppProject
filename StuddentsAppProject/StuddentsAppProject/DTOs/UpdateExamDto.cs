using System.ComponentModel.DataAnnotations;

namespace StuddentsAppProject.Models.DTOs
{
    public class UpdateExamDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public DateTime DateOfExam { get; set; }

        [Required]
        [Range(5, 10)]
        public int ExamMark { get; set; }
    }
}