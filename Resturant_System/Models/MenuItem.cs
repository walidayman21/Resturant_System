using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_System.Models
{
    public class MenuItem : BaseEntity
    {
        [Required (ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(50.00, 9000.00)]
        [Column(TypeName = "decimal(10,2)")]

        public decimal Price { get; set; }

        [StringLength(200)]
        public string? ImgUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsSpicy { get; set; } = false;
        public bool IsHealthy { get; set; } = false;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public int DailyLimit { get; set; } = 50; 
        public int AvailableQuantity { get; set; } = 50; 
    }
}
