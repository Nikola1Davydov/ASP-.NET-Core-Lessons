using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

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
            return View(productsInCart);
        }
        [HttpPost]
        public IActionResult SubmitOrder(UserDeliveryInfo user)
        {
            var existingCart = cartRepository.TryGetByUserId(Constants.UserId);
            var order = new Order
            {
                UserDeliveryInfo = user,
                CartItems = existingCart.CartItems
            };
            ordersRepository.Add(order);
            cartRepository.CleanCartRepository(Constants.UserId);

            return View();
        }
    }
}
