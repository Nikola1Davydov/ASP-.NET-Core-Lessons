using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

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
            Cart cart = cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            Product product = productRepository.TryGetById(productId);
            cartRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int productId)
        {
            Product product = productRepository.TryGetById(productId);
            cartRepository.Remove(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Increase(int productId)
        {
            Product product = productRepository.TryGetById(productId);
            cartRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clean(string userId)
        {
            cartRepository.CleanCartRepository(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
