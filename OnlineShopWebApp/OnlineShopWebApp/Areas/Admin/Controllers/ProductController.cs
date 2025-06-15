using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;

        public ProductController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            List<Product> products = productRepository.GetAll();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int productId)
        {
            Product product = productRepository.TryGetById(productId);
            productRepository.Remove(product);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int productId)
        {
            Product product = productRepository.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productRepository.Update(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
