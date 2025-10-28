using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_System.Context;
using Resturant_System.Models;
using Resturant_System.Models.Enums;
using Resturant_System.ViewModels;
using System.Security.Claims;

namespace Resturant_System.Controllers
{
    public class GuestMenuController : Controller
    {
        private readonly RestaurantDbContext db;
        public GuestMenuController(RestaurantDbContext _context)
        {
            db = _context;
        }
        public async Task<IActionResult> Menu()
        {
            try
            {
                List<MenuItem> menuItems = await db.MenuItems.Include(p => p.Category).ToListAsync();

                return View(menuItems);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occured while loading Menu Items.";
                return View(new List<MenuItem>());
            }
        }
    }
}
