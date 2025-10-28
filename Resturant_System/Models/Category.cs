using System.ComponentModel.DataAnnotations;

namespace Resturant_System.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage ="Name is required")]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(50, ErrorMessage = "Type is required")]
        public string Type { get; set; }
        public bool IsAvailable { get; set; } = true;
        public ICollection<MenuItem>? MenuItems { get; set; }
    }
}
