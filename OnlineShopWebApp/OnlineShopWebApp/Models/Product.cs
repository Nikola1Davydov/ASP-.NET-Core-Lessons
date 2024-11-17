using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0, 100000, ErrorMessage = "Price must be between 0 and 10000 euro")]
        public decimal Cost { get; set; }

        public string? ImagePath { get; set; }

        public Product() 
        {
            Id = instanceCounter;
            instanceCounter += 1;
        }

        public Product(string name, decimal cost, string imagePath, string description) : this()
        {
            Name = name; 
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
