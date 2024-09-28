using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartRepository;

        public CartController(ICartsRepository _cartsRepository, IProductsRepository _productsRepository)
        {
            cartRepository = _cartsRepository;
            productRepository = _productsRepository;
        }

        public IActionResult Index()
        {
            //var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetById(productId);
            //CartsRepository.Add(product, Constants.UserId);
            cartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int productId)
        {
            var product = productRepository.TryGetById(productId);
            //CartsRepository.Remove(product, Constants.UserId);
            cartRepository.Remove(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult IncreaseProductInCart(int productId)
        {
            var product = productRepository.TryGetById(productId);
            //CartsRepository.Remove(product, Constants.UserId);
            cartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult CleanCart()
        {
            cartRepository.CleanCartRepository();
            return RedirectToAction("Index");
        }
    }
}
