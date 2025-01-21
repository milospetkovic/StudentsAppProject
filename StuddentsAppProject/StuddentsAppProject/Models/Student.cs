using System.ComponentModel.DataAnnotations;

namespace StuddentsAppProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string? FirstName { get; set; }
        
        [Display(Name = "Last name")]
        [Required]
        public string? LastName { get; set; }

        [Display(Name = "Date of birth")]
        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "JMBG")]
        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "JMBG must be 13 characters.")]
        public string? JMBG { get; set; }
    }
}
