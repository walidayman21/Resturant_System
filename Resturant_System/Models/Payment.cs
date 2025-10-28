using Resturant_System.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_System.Models
{
    public class Payment : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        [StringLength(100)]
        public string TransactionId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
