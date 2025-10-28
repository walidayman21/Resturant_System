using Resturant_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_System.ViewModels
{
    public class OrderItemVM
    {
        public int Id { get; set; }
        public MenuItem menuItem { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50")]
        public int Quantity { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }


    }
}
