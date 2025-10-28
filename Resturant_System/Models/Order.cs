using Resturant_System.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Resturant_System.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        [StringLength(800)]
        public string? Notes { get; set; }
        [Required(ErrorMessage = "Place is required")]
        public OrderType PlacingOrder { get; set; } = OrderType.DinIn;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public int PreparationTimeMinutes { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Tax { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Discounts { get; set; } = 0;
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DeliveryFee { get; set; } = 0;
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }
        public int? TableNumber { get; set; }
        [StringLength(600)]
        public string? DeliveryAddress { get; set; }
        public int DeliveryTime { get; set; } = 30;
        public Payment Payment { get; set; }

    }
}
