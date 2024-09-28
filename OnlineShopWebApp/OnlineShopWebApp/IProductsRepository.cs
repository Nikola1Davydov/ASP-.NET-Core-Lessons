using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        List<Product> GetAllProducts { get; }
        Product TryGetById(int id);
    }
}
