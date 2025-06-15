using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            List<Order> orders = ordersRepository.GetAllOrders();
            return View(orders);
        }

        public IActionResult Details(string orderId)
        {
            Order order = ordersRepository.TryGetById(new Guid(orderId));
            return View(order);
        }
        public IActionResult Edit(Guid orderId, OrderStatusesEnum status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}
