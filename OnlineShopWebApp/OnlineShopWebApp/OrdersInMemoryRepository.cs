using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> _orders = new List<Order>();

        public void Add(Order order)
        {
            order.Nummer = _orders.Count + 1;
            _orders.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        public Order TryGetById(Guid id)
        {
            return _orders.FirstOrDefault(order => order.Id == id);
        }

        public void UpdateStatus(Guid orderId, OrderStatusesEnum status)
        {
            Order order = TryGetById(orderId);
            if (order != null)
            {
                order.Status = status;
            }
        }
    }
}
