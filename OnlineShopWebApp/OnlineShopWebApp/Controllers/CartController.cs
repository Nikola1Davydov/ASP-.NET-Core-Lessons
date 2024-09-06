using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductRepository productRepository;

        public CartController()
        {
            productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
