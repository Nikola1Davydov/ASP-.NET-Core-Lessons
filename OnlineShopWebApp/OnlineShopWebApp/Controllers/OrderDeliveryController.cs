using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class OrderDeliveryController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartRepository;

        public OrderDeliveryController(IProductsRepository _productsRepository, ICartsRepository _cartRepository)
        {
            productRepository = _productsRepository;
            cartRepository = _cartRepository;
        }

        public IActionResult Index(string userId)
        {
            var productsInCart = cartRepository.TryGetByUserId(userId);
            return View(productsInCart);
        }

        public IActionResult SubmitOrder()
        {
            cartRepository.CleanCartRepository();
            return RedirectToAction("Index");
        }
    }
}
