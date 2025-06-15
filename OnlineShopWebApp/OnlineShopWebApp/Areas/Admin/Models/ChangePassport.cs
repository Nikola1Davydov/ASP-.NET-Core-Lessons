using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ChangePassport
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password be filled")]
        [StringLength(100, MinimumLength = 4)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirm must be filled")]
        [StringLength(100, MinimumLength = 4)]
        [Compare("Password", ErrorMessage = "Password is not the same")]
        public string ConfirmPassword { get; set; }
    }
}
