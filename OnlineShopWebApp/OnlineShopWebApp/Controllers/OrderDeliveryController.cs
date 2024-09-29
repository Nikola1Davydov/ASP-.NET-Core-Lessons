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
        public IActionResult SubmitOrder(OrderDelivery orderDelivery)
        {
            var existingCart = cartRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCart);
            cartRepository.CleanCartRepository(Constants.UserId);
            return View();
        }
    }
}
