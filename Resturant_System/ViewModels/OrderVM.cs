using Resturant_System.Models;
using Resturant_System.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_System.ViewModels
{
    public class OrderVM
    {
        public int CustomerId { get; set; }
        public string? Notes { get; set; }

        public List<int> MenuItemIds { get; set; }
        public int Quantity { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}
