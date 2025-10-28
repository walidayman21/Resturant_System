using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Resturant_System.Context;
using Resturant_System.Helpers;
using Resturant_System.Models;
using Resturant_System.Models.Enums;
using Resturant_System.ViewModels;

namespace Resturant_System.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly RestaurantDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(RestaurantDbContext _context, UserManager<ApplicationUser> userManager)
        {
            db = _context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var menuItem = await db.MenuItems
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menuItem == null || !menuItem.IsAvailable)
            {
                TempData["ErrorMessage"] = "Item not available!";
                return RedirectToAction("Menu", "GuestMenu");
            }

            var currentOrderId = SessionHelper.GetCurrentOrderId(HttpContext.Session);
            Order order;

            if (currentOrderId.HasValue)
            {
                order = await db.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(o => o.Id == currentOrderId.Value && o.OrderStatus == OrderStatus.Draft);

                if (order == null)
                {
                    order = await CreateDraftOrder();
                }
            }
            else
            {
                order = await CreateDraftOrder();
            }

            var existingOrderItem = await db.OrderItems
                .FirstOrDefaultAsync(oi => oi.OrderId == order.Id && oi.MenuItemId == id);

            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += quantity;
                existingOrderItem.Subtotal = existingOrderItem.UnitPrice * existingOrderItem.Quantity;
                existingOrderItem.UpdatedAt = DateTime.Now;
            }

            else
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    MenuItemId = menuItem.Id,
                    Quantity = quantity,
                    UnitPrice = menuItem.Price,
                    Subtotal = menuItem.Price * quantity,
                    CreatedAt = DateTime.Now
                };
                db.OrderItems.Add(orderItem);
            }

            await db.SaveChangesAsync();
            await UpdateOrderTotals(order.Id);

            TempData["SuccessMessage"] = $"✅ {menuItem.Name} added to cart!";
            return RedirectToAction("Menu", "GuestMenu");
        }

        [HttpGet]
        public async Task<IActionResult> ViewCart()
        {
            var currentOrderId = SessionHelper.GetCurrentOrderId(HttpContext.Session);

            if (!currentOrderId.HasValue)
            {
                return View(new Order { OrderItems = new List<OrderItem>() });
            }

            var order = await db.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == currentOrderId.Value && o.OrderStatus == OrderStatus.Draft);

            if (order == null)
            {
                SessionHelper.ClearCurrentOrder(HttpContext.Session);
                return View(new Order { OrderItems = new List<OrderItem>() });
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int orderItemId, int quantity)
        {
            var orderItem = await db.OrderItems
                .Include(oi => oi.Order)
                .FirstOrDefaultAsync(oi => oi.Id == orderItemId && !oi.IsDeleted);

            if (orderItem == null)
            {
                TempData["ErrorMessage"] = "Item not found!";
                return RedirectToAction("ViewCart");
            }

            if (quantity <= 0)
            {
                orderItem.IsDeleted = true;
                orderItem.UpdatedAt = DateTime.Now;
                TempData["SuccessMessage"] = "Item removed from cart";
            }
            else
            {
                orderItem.Quantity = quantity;
                orderItem.Subtotal = orderItem.UnitPrice * quantity;
                orderItem.UpdatedAt = DateTime.Now;
                TempData["SuccessMessage"] = "Quantity updated";
            }

            await db.SaveChangesAsync();
            await UpdateOrderTotals(orderItem.OrderId);

            return RedirectToAction("ViewCart");
        }


        //[HttpPost]
        //public async Task<IActionResult> UpdateNotes(int orderItemId, string? notes)
        //{
        //    var orderItem = await db.OrderItems
        //        .FirstOrDefaultAsync(oi => oi.Id == orderItemId && !oi.IsDeleted);

        //    if (orderItem != null)
        //    {
        //        orderItem.Notes = notes;
        //        orderItem.UpdatedAt = DateTime.Now;
        //        await db.SaveChangesAsync();
        //        TempData["SuccessMessage"] = "Notes updated";
        //    }

        //    return RedirectToAction("ViewCart");
        //}

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int orderItemId)
        {
            var orderItem = await db.OrderItems
                .Include(oi => oi.MenuItem)
                .FirstOrDefaultAsync(oi => oi.Id == orderItemId && !oi.IsDeleted);

            if (orderItem != null)
            {
                orderItem.IsDeleted = true;
                orderItem.UpdatedAt = DateTime.Now;
                await db.SaveChangesAsync();
                await UpdateOrderTotals(orderItem.OrderId);

                TempData["SuccessMessage"] = $"{orderItem.MenuItem.Name} removed from cart";
            }

            return RedirectToAction("ViewCart");
        }

        //[HttpGet]
        //public async Task<IActionResult> Checkout()
        //{
        //    var currentOrderId = SessionHelper.GetCurrentOrderId(HttpContext.Session);

        //    if (!currentOrderId.HasValue)
        //    {
        //        TempData["ErrorMessage"] = "Your cart is empty!";
        //        return RedirectToAction("Menu", "GuestMenu");
        //    }

        //    var order = await db.Orders
        //        .Include(o => o.OrderItems)
        //            .ThenInclude(oi => oi.MenuItem)
        //        .FirstOrDefaultAsync(o => o.Id == currentOrderId.Value && o.OrderStatus == OrderStatus.Draft);

        //    if (order == null)
        //    {
        //        TempData["ErrorMessage"] = "Your cart is empty!";
        //        return RedirectToAction("Menu", "GuestMenu");
        //    }

        //    return View(order);
        //}

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var currentOrderId = SessionHelper.GetCurrentOrderId(HttpContext.Session);

            if (!currentOrderId.HasValue)
            {
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Menu", "GuestMenu");
            }

            var order = await db.Orders
                .Include(o => o.Customer)  
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == currentOrderId.Value
                                      && o.OrderStatus == OrderStatus.Draft
                                      && !o.IsDeleted);  

            if (order == null || !order.OrderItems.Any(oi => !oi.IsDeleted))
            {
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Menu", "GuestMenu");
            }

            ViewBag.OrderTypes = Enum.GetValues(typeof(OrderType))
                .Cast<OrderType>()
                .Select(o => new SelectListItem { Text = o.ToString(), Value = ((int)o).ToString() })
                .ToList();

            ViewBag.PaymentMethods = Enum.GetValues(typeof(PaymentMethod))
                .Cast<PaymentMethod>()
                .Select(p => new SelectListItem { Text = p.ToString(), Value = ((int)p).ToString() })
                .ToList();

            

            return View(order);
        }

        public async Task<IActionResult> OrderSuccess(int id)
        {
            var order = await db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                        .ThenInclude(m => m.Category)
                        .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmOrder(int orderId, int orderType, int paymentMethod,
            string? orderNotes, string? deliveryAddress, int? tableNumber)
        {
            var order = await db.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == orderId
                                      && o.OrderStatus == OrderStatus.Draft
                                      && !o.IsDeleted);

            if (order == null || !order.OrderItems.Any(oi => !oi.IsDeleted))
            {
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Menu", "GuestMenu");
            }

            var orderTypeEnum = (OrderType)orderType;
            var paymentMethodEnum = (PaymentMethod)paymentMethod;

            if (orderTypeEnum == OrderType.Delivery && string.IsNullOrWhiteSpace(deliveryAddress))
            {
                TempData["ErrorMessage"] = "Delivery address is required!";
                return RedirectToAction("ViewCart");
            }

            order.PlacingOrder = orderTypeEnum;
            order.OrderStatus = OrderStatus.Pending;
            order.Notes = orderNotes;
            order.DeliveryAddress = deliveryAddress;
            order.TableNumber = tableNumber;
            order.UpdatedAt = DateTime.Now;

            if (orderTypeEnum == OrderType.Delivery)
            {
                order.DeliveryFee = 30.00m;
            }
            else
            {
                order.DeliveryFee = 0;
            }

            await db.SaveChangesAsync();
            await UpdateOrderTotals(order.Id);

            var payment = new Payment
            {
                OrderId = order.Id,
                PaymentMethod = paymentMethodEnum,
                PaymentStatus = PaymentStatus.Pending,
                TotalAmount = order.TotalAmount,
                TransactionId = $"TXN{order.Id}{DateTime.Now:yyyyMMddHHmmss}",
                CreatedAt = DateTime.Now
            };
            db.Payments.Add(payment);
            await db.SaveChangesAsync();

            SessionHelper.ClearCurrentOrder(HttpContext.Session);

            TempData["SuccessMessage"] = $"Order #{order.Id} placed successfully!";
            return RedirectToAction("OrderSuccess", new { id = order.Id });
        }


        //private async Task<Order> CreateDraftOrder()
        //{
        //    var order = new Order
        //    {
        //        CustomerId = 1,
        //        OrderStatus = OrderStatus.Draft,
        //        PlacingOrder = OrderType.DinIn,
        //        CreatedAt = DateTime.Now
        //    };

        //    db.Orders.Add(order);
        //    await db.SaveChangesAsync();

        //    SessionHelper.SetCurrentOrderId(HttpContext.Session, order.Id);
        //    return order;
        //}

        private async Task<Order> CreateDraftOrder()
        {
            var userId = _userManager.GetUserId(User);

            var customer = await db.Customers
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);

            if (customer == null)
            {
                var user = await _userManager.GetUserAsync(User);

                customer = new Customer
                {
                    UserId = userId,
                    Name = user.UserName ?? "Guest",
                    PhoneNumber = user.PhoneNumber ?? "",
                    Address = user.Address,
                    CreatedAt = DateTime.Now
                };

                db.Customers.Add(customer);
                await db.SaveChangesAsync();
            }

            var order = new Order
            {
                CustomerId = customer.Id, 
                OrderStatus = OrderStatus.Draft,
                PlacingOrder = OrderType.DinIn,
                CreatedAt = DateTime.Now
            };

            db.Orders.Add(order);
            await db.SaveChangesAsync();

            SessionHelper.SetCurrentOrderId(HttpContext.Session, order.Id);
            return order;
        }

        private async Task UpdateOrderTotals(int orderId)
        {
            var order = await db.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null) return;

            var activeItems = order.OrderItems.Where(oi => !oi.IsDeleted).ToList();
            order.Subtotal = activeItems.Sum(oi => oi.Subtotal);

            decimal discount = 0;
            var currentHour = DateTime.Now.Hour;
            if (currentHour >= 15 && currentHour < 17)
            {
                discount = order.Subtotal * 0.20m;
            }

            if (order.Subtotal > 100)
            {
                var bulkDiscount = order.Subtotal * 0.10m;
                discount = Math.Max(discount, bulkDiscount);
            }

            order.Discounts = discount;

            order.Tax = (order.Subtotal - discount) * 0.085m;

            order.TotalAmount = order.Subtotal - order.Discounts + order.Tax + order.DeliveryFee;
            order.UpdatedAt = DateTime.Now;

            await db.SaveChangesAsync();
        }

        // Admin Actions
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await db.Orders.Include(m => m.Customer).ToListAsync();
            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            var vm = new OrderDetailsAdminVM
            {
                Id = order.Id,
                Notes = order.Notes,
                PlacingOrder = order.PlacingOrder.ToString(),
                OrderStatus = order.OrderStatus.ToString(),
                PreparationTimeMinutes = order.PreparationTimeMinutes,
                Subtotal = order.Subtotal,
                Tax = order.Tax,
                Discounts = order.Discounts,
                DeliveryFee = order.DeliveryFee,
                TotalAmount = order.TotalAmount,
                TableNumber = order.TableNumber,
                DeliveryAddress = order.DeliveryAddress,
                DeliveryTime = order.DeliveryTime,
                Customer = order.Customer,
                Payment = order.Payment,
                OrderItems = order.OrderItems.Select(oi => new OrderItemVM
                {
                    Id = oi.Id,
                    menuItem = oi.MenuItem,
                    Quantity = oi.Quantity,
                    Notes = oi.Notes
                }).ToList()
            };

            return View(vm);
        }


        //public async Task<IActionResult> GetAll()
        //{
        //    var orders = await db.Orders.Include(m => m.Customer).ToListAsync();
        //    return View(orders);
        //}
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var order = await db.Orders.Include(m => m.Customer).Include(o => o.OrderItems).Include(o => o.Payment).FirstOrDefaultAsync(x => x.Id == id);
        //    return View(order);
        //}


    }
}

