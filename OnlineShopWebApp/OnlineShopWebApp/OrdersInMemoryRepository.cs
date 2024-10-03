using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> _orders = new List<Order>();

        public void Add(Order order)
        {
            _orders.Add(order);
        }
    }
}
