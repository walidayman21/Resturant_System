using Resturant_System.Models;
using System.Collections.Generic;

namespace Resturant_System.ViewModels
{
    public class OrderDetailsAdminVM
    {
        // معلومات الطلب الأساسية
        public int Id { get; set; }
        public string? Notes { get; set; }
        public string PlacingOrder { get; set; }
        public string OrderStatus { get; set; }
        public int PreparationTimeMinutes { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Discounts { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalAmount { get; set; }

        public int? TableNumber { get; set; }
        public string? DeliveryAddress { get; set; }
        public int DeliveryTime { get; set; }

        // معلومات العميل
        public Customer? Customer { get; set; }

        // عناصر الطلب
        public List<OrderItemVM> OrderItems { get; set; }

        // معلومات الدفع
        public Payment? Payment { get; set; }

    }
}
