using System.ComponentModel.DataAnnotations;

namespace Arc_07_Project.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is reuiqred.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
