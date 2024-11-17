using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User name must be filled")]
        [EmailAddress(ErrorMessage = "email is not valid")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must be filled")]
        [StringLength(100, MinimumLength = 4)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
