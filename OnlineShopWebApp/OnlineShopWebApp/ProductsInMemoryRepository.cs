using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> _products;
        public ProductsInMemoryRepository()
        {
            _products = new List<Product>()
            {
                new Product("Revit Mirrors", 12, @"/images/RevitMirrors.png", "This Revit Mirror pack is designed to cater to various mirror types, from classic to more practical and modern wall mirrors. Including popular Revit Mirrors by famous furniture brands and other trendy designs. "),
                new Product("Revit Kitchen Islands Families ", 15, @"/images/RevitKitchenIslandsFamilies.png", "This Revit Kitchen Island pack is designed to cater to various kitchen islands, from classic to more practical and modern kitchen worktops. Including some popular kitchen islands from IKEA and other trendy designs. "),
                new Product("Revit Dining Chairs", 29, @"/images/RevitDiningChairs.png", "This Revit Dining Chairs pack is designed to cater to a wide range of projects, perfect for residential, commercial, retail projects, and all interior design projects. "),
                new Product("Revit Bathtubs", 19, @"/images/RevitBathtubs.png", "Our Revit Bathtub Families are generic and aim to provide maximum flexibility to adjust the bathtub to your specific design. "),
            };
        }
        public List<Product> GetAll()
        {
            return _products; 
        }

        public void Add(Product product)
        {
            product.ImagePath = @"/images/RevitMirrors.png";
            _products.Add(product);
        }
        public void Remove(Product product)
        {
            _products.Remove(product);
        }

        public Product TryGetById(int id)
        {
            return _products.FirstOrDefault(products => products.Id == id);
        }
        public void Update(Product product)
        {
            Product existingProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
        }
    }
}
