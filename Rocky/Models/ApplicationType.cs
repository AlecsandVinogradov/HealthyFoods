using System.ComponentModel.DataAnnotations;

namespace HealthyFood.Models
{
    public class ApplicationType
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole is not null")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lenght string must be between 2 and 50 char")]
        public string Name { get; set; }
    }
}
