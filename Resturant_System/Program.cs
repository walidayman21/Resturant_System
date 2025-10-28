using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resturant_System.Context;
using Resturant_System.Data;
using Resturant_System.Middlewares;
using Resturant_System.Models;
using Resturant_System.Services;
using System.Threading.Tasks;

namespace Resturant_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<RestaurantDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ResDbContext"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RestaurantDbContext>();

            builder.Services.AddSingleton<SingeltonService>();
            builder.Services.AddTransient<TransientService>();
            builder.Services.AddScoped<ScopedService>();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await RoleSeeder.UserRole(userManager, roleManager);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseMiddleware<OpenTimeMiddleware>();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            
            // ??? app.Run()
            app.UseSession();

            app.Run();
        }
    }
}
