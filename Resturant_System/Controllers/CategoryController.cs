using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_System.Context;
using Resturant_System.Models;

namespace Resturant_System.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly RestaurantDbContext _db;

        public CategoryController(RestaurantDbContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> GetAll()
        {
            var categories = await _db.Categories
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedAt = DateTime.Now;
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = $"✅ Category '{category.Name}' added successfully!";
                return RedirectToAction(nameof(GetAll));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null || category.IsDeleted)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category updatedCategory)
        {
            if (id != updatedCategory.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var existing = await _db.Categories.FindAsync(id);
                if (existing == null)
                    return NotFound();

                existing.Name = updatedCategory.Name;
                existing.Type = updatedCategory.Type;
                existing.IsAvailable = updatedCategory.IsAvailable;
                existing.UpdatedAt = DateTime.Now;

                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "✅ Category updated successfully!";
                return RedirectToAction(nameof(GetAll));
            }

            return View(updatedCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsDeleted = true;
            category.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = $"🗑️ Category '{category.Name}' deleted successfully!";
            return RedirectToAction(nameof(GetAll));
        }
    }
}
