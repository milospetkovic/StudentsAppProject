using System.ComponentModel.DataAnnotations;

namespace StuddentsAppProject.Models.DTOs
{
    public class UpdateExamDto : CreateExamDto
    {
        [Required]
        public int Id { get; set; }
    }
}