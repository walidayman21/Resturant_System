using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_System.Context;
using Resturant_System.Models;

namespace Resturant_System.Controllers
{
    public class CustomerController : Controller
    {
        private readonly RestaurantDbContext db;

        public CustomerController(RestaurantDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> GetAll()
        {
            var customers = await db.Customers.Where(m => !m.IsDeleted).ToListAsync();
            //var customers = await db.Customers.ToListAsync();

            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.IsDeleted = true;
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Password");
            await db.SaveChangesAsync();

            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> GetById(int id)
        {
            var customer = await db.Customers.Include(o => o.Orders).ThenInclude(i => i.OrderItems).FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            var cust = await db.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            if (cust == null)
            {
                return NotFound();
            }

            cust.Name = customer.Name;
            cust.PhoneNumber = customer.PhoneNumber;
            cust.Address = customer.Address;

            db.Customers.Update(cust);
            await db.SaveChangesAsync();

            TempData["SuccessMessage"] = "✅ Customer updated successfully!";
            return RedirectToAction("GetAll");
        }

    }
}
