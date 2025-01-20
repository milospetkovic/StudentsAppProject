using System.ComponentModel.DataAnnotations;

namespace StuddentsAppProject.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
