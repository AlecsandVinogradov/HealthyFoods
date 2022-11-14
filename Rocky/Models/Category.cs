using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthyFood.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } //первичный ключ таблицы
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required] //обезательное заполнение 
        [Range(1, int.MaxValue, ErrorMessage = "Display Order for Category must be greater than 0")]
        public int DisplayOrder { get; set; }

    }
}
