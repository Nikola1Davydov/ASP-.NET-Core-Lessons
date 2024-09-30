using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Authentication authentication)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrationButton(Authentication authentication)
        {
            return RedirectToAction("Registration");
        }
    }
}
