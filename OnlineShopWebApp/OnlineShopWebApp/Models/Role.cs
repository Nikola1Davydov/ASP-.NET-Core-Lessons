using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? UserId { get; set; }

        public Role()
        {
            Id = instanceCounter;
            instanceCounter += 1;
        }
    }
}
