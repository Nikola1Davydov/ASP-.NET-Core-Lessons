using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        void Add(Product product);
        void Remove(Product product);
        void Update(Product product);
    }
}
