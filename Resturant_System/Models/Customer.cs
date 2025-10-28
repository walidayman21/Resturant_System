using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_System.Models
{
    public class Customer : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public string? UserId { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 digits")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must contain only digits")]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
