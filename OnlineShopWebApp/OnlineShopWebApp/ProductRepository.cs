using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Revit Mirrors", 12, @"/images/RevitMirrors.png", "This Revit Mirror pack is designed to cater to various mirror types, from classic to more practical and modern wall mirrors. Including popular Revit Mirrors by famous furniture brands and other trendy designs. "),
            new Product("Revit Kitchen Islands Families ", 15, @"/images/RevitKitchenIslandsFamilies.png", "This Revit Kitchen Island pack is designed to cater to various kitchen islands, from classic to more practical and modern kitchen worktops. Including some popular kitchen islands from IKEA and other trendy designs. "),
            new Product("Revit Dining Chairs", 29, @"/images/RevitDiningChairs.png", "This Revit Dining Chairs pack is designed to cater to a wide range of projects, perfect for residential, commercial, retail projects, and all interior design projects. "),
            new Product("Revit Bathtubs", 19, @"/images/RevitBathtubs.png", "Our Revit Bathtub Families are generic and aim to provide maximum flexibility to adjust the bathtub to your specific design. "),
        };

        public List<Product> GetAll()
        {
            return products;
        }
        public Product TryGetById( int id)
        {
            return products.FirstOrDefault(products => products.Id == id);
        }
    }
}
