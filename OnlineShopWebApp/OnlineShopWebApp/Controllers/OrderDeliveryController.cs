using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderDeliveryController : Controller
    {
        private readonly ICartsRepository cartRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderDeliveryController(IOrdersRepository _ordersRepository, ICartsRepository _cartRepository)
        {
            cartRepository = _cartRepository;
            ordersRepository = _ordersRepository;
        }

        public IActionResult Index(string userId)
        {
            var productsInCart = cartRepository.TryGetByUserId(userId);
            if (productsInCart == null) { return NotFound(); }
            return View(productsInCart);
        }
        [HttpPost]
        public IActionResult SubmitOrder(UserDeliveryInfo user)
        {
            
            var existingCart = cartRepository.TryGetByUserId(Constants.UserId);
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    UserDeliveryInfo = user,
                    //OrderStatuses = new List<string> { "Создан", "Обработан", "В пути", "Отменен", "Доставлен" },
                    CartItems = existingCart.CartItems
                };
                //order.SelectedStatus = order.OrderStatuses.FirstOrDefault();
                ordersRepository.Add(order);
                cartRepository.CleanCartRepository(Constants.UserId);
                return RedirectToAction("OrderConfirmation");
            }
            return View("Index", existingCart);
        }
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
