using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Cart> _orders = new List<Cart>();

        public void Add(Cart cart)
        {
            _orders.Add(cart);
        }
    }
}
