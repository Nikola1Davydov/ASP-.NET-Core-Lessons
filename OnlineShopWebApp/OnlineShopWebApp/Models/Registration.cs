using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "User name must be filled")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "User name length must be min 2 symbols and max 25 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "User name must be filled")]
        public int Age { get; set; }
        //public string Phone { get; set; }

        [Required(ErrorMessage = "Email must be filled")]
        [EmailAddress(ErrorMessage ="email is not valid")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password be filled")]
        [StringLength(100, MinimumLength = 4)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirm must be filled")]
        [StringLength(100, MinimumLength = 4)]
        [Compare("Password", ErrorMessage = "Password is not the same")]
        public string PasswordRepeat { get; set; }
    }
}
