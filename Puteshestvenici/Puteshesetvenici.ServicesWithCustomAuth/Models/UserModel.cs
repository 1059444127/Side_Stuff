using System.ComponentModel.DataAnnotations;

namespace Puteshesetvenici.ServicesWithCustomAuth.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} symbols long", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}