using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        void Add(Order orders);
    }
}