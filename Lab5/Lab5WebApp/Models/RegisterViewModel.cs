using System.ComponentModel.DataAnnotations;

namespace Lab5WebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(500)]
        public string FullName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\d\s:]).{8,16}$",
            ErrorMessage = "Password must have 1 uppercase letter, 1 digit, and 1 special character.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Phone must be in +380 format.")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
