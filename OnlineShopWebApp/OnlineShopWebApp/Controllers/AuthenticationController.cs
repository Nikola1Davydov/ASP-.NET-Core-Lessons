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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            return RedirectToAction("Login");
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            return RedirectToAction("Registration");
        }
    }
}
