using System.ComponentModel.DataAnnotations;

namespace Conexia.SR.CrossCutting.Identity.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(25, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
