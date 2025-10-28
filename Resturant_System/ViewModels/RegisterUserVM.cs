using System.ComponentModel.DataAnnotations;

namespace Resturant_System.ViewModels
{
    public class RegisterUserVM
    {
        public int id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
