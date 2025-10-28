using Microsoft.AspNetCore.Identity;

namespace Resturant_System.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Address { get; set; }
    }
}
