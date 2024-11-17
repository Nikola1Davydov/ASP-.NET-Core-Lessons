using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "User name must be filled")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "User name length must be min 2 symbols and max 25 symbols")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email must be filled")]
        [EmailAddress(ErrorMessage = "email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone must be filled")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "City must be filled")]
        public string City { get; set; }

        [Required(ErrorMessage = "DeliveryAddress must be filled")]
        public string DeliveryAddress { get; set; }
    }
}
