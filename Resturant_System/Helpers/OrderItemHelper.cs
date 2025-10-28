using Resturant_System.Models;
using System.Globalization;
using System.Text.Json;

namespace Resturant_System.Helpers
{
    public class OrderItemHelper
    {
        private const string OrderItemKey = "ShoppingCart";

        public static List<OrderItem> GetOrderItem(ISession session)
        {
            var OrderItemJson = session.GetString(OrderItemKey);
            if (string.IsNullOrEmpty(OrderItemJson))
            {
                return new List<OrderItem>();
            }
            return JsonSerializer.Deserialize<List<OrderItem>>(OrderItemJson) ?? new List<OrderItem>();
        }

        public static void SaveCart(ISession session, List<OrderItem> items)
        {
            var cartJson = JsonSerializer.Serialize(items);
            session.SetString(OrderItemKey, cartJson);
        }

        public static void ClearCart(ISession session)
        {
            session.Remove(OrderItemKey);
        }
    }
}
