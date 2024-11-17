using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        void Add(Order orders);
        List<Order> GetAllOrders();
        Order TryGetById(Guid id);
        void UpdateStatus(Guid orderId, OrderStatusesEnum status);
    }
}