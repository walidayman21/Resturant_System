using Resturant_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Resturant_System.ViewModels
{
    public class QuickOrderViewModel : BaseEntity
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } = string.Empty;
        public decimal MenuItemPrice { get; set; }
        public string? MenuItemImage { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Subtotal { get; set; }

        // Customer Info
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(11, MinimumLength = 11)]
        public string CustomerPhone { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Address { get; set; }

        public string? Notes { get; set; }
        public string? ItemNotes { get; set; }
    }
}
