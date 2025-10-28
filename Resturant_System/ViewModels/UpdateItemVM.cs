using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_System.Models;
using Resturant_System.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_System.ViewModels
{
    public class UpdateItemVM
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(1.00, 9999.99)]
        [PositivePrice]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsSpicy { get; set; } = false;
        public bool IsHealthy { get; set; } = false;

        [Required]
        public int CategoryId { get; set; }

    }
}
