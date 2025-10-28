using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_System.Models
{
    public class OrderItem : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int MenuItemId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; } 
        public int Quantity { get; set; }

        [StringLength(800)]
        public string? Notes { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("MenuItemId")]
        public MenuItem MenuItem { get; set; }

    }
}
