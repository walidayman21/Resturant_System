using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_System.Context;
using Resturant_System.Models;
using Resturant_System.ViewModels;

namespace Resturant_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RestaurantDbContext db;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RestaurantDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            db = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM NeweUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Try again...");
            }

            ApplicationUser modelUser = new ApplicationUser()
            {
                UserName = NeweUser.UserName,
                Address = NeweUser.Address,
                //PhoneNumber = NeweUser.PhoneNumber
            };

            IdentityResult Res = await _userManager.CreateAsync(modelUser, NeweUser.Password);

            if (Res.Succeeded)
            {
                await _userManager.AddToRoleAsync(modelUser, "Customer");
                await _signInManager.SignInAsync(modelUser, isPersistent: false);
                return RedirectToAction("menu", "geustmenu");
            }

            else
            {
                foreach (var ErrorItem in Res.Errors)
                {
                    ModelState.AddModelError(string.Empty, ErrorItem.Description);
                }
            }

                return View(NeweUser);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View(loginUser);
            }

            ApplicationUser user = await _userManager.FindByNameAsync(loginUser.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(loginUser);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var User = await _userManager.FindByNameAsync(loginUser.UserName);
                var role = await _userManager.GetRolesAsync(User);

                if (role.Contains("Admin"))
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (role.Contains("Customer"))
                {
                    return RedirectToAction("Menu", "guestmenu");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(loginUser);
        }
            
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}
