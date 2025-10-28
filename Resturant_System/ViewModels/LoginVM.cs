using System.ComponentModel.DataAnnotations;

namespace Resturant_System.ViewModels
{
    public class LoginVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
