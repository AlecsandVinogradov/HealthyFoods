using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyFood.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string Image { get; set; }

        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")] //связь между таблицами Category и Product
        public virtual Category Category { get; set; }

        [Display(Name = "Aplplication Type")]
        public int ApplicationTypeId { get; set; }
        [ForeignKey("ApplicationTypeId")] //связь между таблицами Category и ApplicationType
        public virtual ApplicationType ApplicationType { get; set; }
    }
}
