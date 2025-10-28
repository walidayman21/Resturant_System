using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant_System.Context;
using Resturant_System.Models;
using Resturant_System.ViewModels;

namespace Resturant_System.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly RestaurantDbContext db;
        public MenuItemController(RestaurantDbContext _context)
        {
            db = _context;
        }
        #region GetAllItems
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
        #endregion

        #region CreateItem
        public async Task<ActionResult> Create()
        {
            var category = await db.Categories.ToListAsync();
            CreateItemVM createVM = new CreateItemVM()
            {
                Categories = new SelectList(category, "Id", "Name")
            };
            return View(createVM);
        }

        //[HttpPost]
        //public async Task<ActionResult> Create(ItemVM newItem)
        //{
        //    MenuItem oldItem = new MenuItem()
        //    {
        //        Name = newItem.Name,
        //        Description = newItem.Description,
        //        Price = newItem.Price,
        //        ImgUrl = newItem.ImgUrl,
        //        CategoryId = newItem.CategoryId,
        //        IsHealthy = newItem.IsHealthy,
        //        IsSpicy = newItem.IsSpicy,
        //    };

        //    db.MenuItems.Add(oldItem);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Menu");
        //}

        [HttpPost]
        public async Task<ActionResult> Create(CreateItemVM newItem, IFormFile? ImgUrl)
        {
            if (!ModelState.IsValid)
            {
                var category = await db.Categories.ToListAsync();
                newItem.Categories = new SelectList(category, "Id", "Name");

                return View(newItem);
            }

            string? imagePath = null;

            // Handle file upload
            if (ImgUrl != null && ImgUrl.Length > 0)
            {
                // Create uploads folder if it doesn't exist
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "menu");
                Directory.CreateDirectory(uploadsFolder);

                // Generate unique filename
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImgUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save file to server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImgUrl.CopyToAsync(fileStream);
                }

                // Store relative path for database
                imagePath = "/images/menu/" + uniqueFileName;
            }

            MenuItem oldItem = new MenuItem()
            {
                Name = newItem.Name,
                Description = newItem.Description,
                Price = newItem.Price,
                ImgUrl = imagePath, 
                CategoryId = newItem.CategoryId,
                IsHealthy = newItem.IsHealthy,
                IsSpicy = newItem.IsSpicy,
            };

            db.MenuItems.Add(oldItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Menu");
        }
        #endregion

        #region GetById
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await db.MenuItems.Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        } 
        #endregion

        #region Update Item

        public async Task<ActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await db.MenuItems.Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            var oldItem = new CreateItemVM
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                //ImgUrl = item.ImgUrl,
                CategoryId = item.CategoryId,
                IsHealthy = item.IsHealthy,
                IsSpicy = item.IsSpicy,
                Categories = new SelectList(await db.Categories.ToListAsync(), "Id", "Name")
            };
            return View(oldItem);
        }

        //[HttpPost]
        //public async Task<ActionResult> Update(ItemVM EditItem)
        //{
        //    var item = await db.MenuItems.FirstOrDefaultAsync(m => m.Id == EditItem.Id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    item.Name = EditItem.Name;
        //    item.Description = EditItem.Description;
        //    item.Price = EditItem.Price;
        //    item.ImgUrl = EditItem.ImgUrl;
        //    item.CategoryId = EditItem.CategoryId;
        //    item.IsHealthy = EditItem.IsHealthy;
        //    item.IsSpicy = EditItem.IsSpicy;

        //    db.MenuItems.Update(item);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Menu");
        //}

        [HttpPost]
        public async Task<ActionResult> Update(UpdateItemVM EditItem, IFormFile? ImgUrl)
        {
            if (!ModelState.IsValid)
            {
                //var categories = await db.Categories.ToListAsync();
                //EditItem.Categories = new SelectList(categories, "Id", "Name");
                return View();
            }

            var item = await db.MenuItems.FirstOrDefaultAsync(m => m.Id == EditItem.Id);
            if (item == null)
            {
                return NotFound();
            }

            // Handle file upload
            if (ImgUrl != null && ImgUrl.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "menu");
                Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImgUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImgUrl.CopyToAsync(fileStream);
                }

                item.ImgUrl = "/images/menu/" + uniqueFileName;
            }

            item.Name = EditItem.Name;
            item.Description = EditItem.Description;
            item.Price = EditItem.Price;
            item.CategoryId = EditItem.CategoryId;
            item.IsHealthy = EditItem.IsHealthy;
            item.IsSpicy = EditItem.IsSpicy;

            db.MenuItems.Update(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Menu");
        }
        #endregion

        #region Delete Item
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await db.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.IsDeleted = true;
            item.IsAvailable = false;
            db.MenuItems.Update(item);
            await db.SaveChangesAsync();
            //TempData["SuccessMessage"] = $"{item.Name} has been deleted successfully.";

            return RedirectToAction("Menu");
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsUniqueName(string name)
        {
            if (await db.MenuItems.AnyAsync(m => m.Name == name))
            {
                return Json($"Name {name} is already Exist.");
            }

            return Json(true);
        } 
        #endregion

    }
}
