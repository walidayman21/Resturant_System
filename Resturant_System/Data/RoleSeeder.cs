using Microsoft.AspNetCore.Identity;
using Resturant_System.Models;

namespace Resturant_System.Data
{
    public static class RoleSeeder
    {
        public static async Task UserRole(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Customer" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string adminUserName = "admin";
            ApplicationUser adminUser = await userManager.FindByNameAsync(adminUserName);

            if (adminUser == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminUserName,
                    Address = "Main Office"
                };

                var result = await userManager.CreateAsync(admin, "Aa@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
