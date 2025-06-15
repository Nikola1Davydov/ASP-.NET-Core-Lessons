using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;

        public ProductController(IProductsRepository _productsRepository)
        {
            productRepository = _productsRepository;
        }

        public IActionResult Index(int id)
        {
            Product product = productRepository.TryGetById(id);

            return View(product);
        }
    }
}
