using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;
        public AccountController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }

            UserAccount userAccount = usersManager.TryGetByName(login.UserName);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "User dont exist");
                return RedirectToAction(nameof(Login));
            }
            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Wrong password");
                return RedirectToAction(nameof(Login));
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            if (registration.Name == registration.Password)
            {
                ModelState.AddModelError("", "Name and password should not be the same ");
            }
            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    Name = registration.Name,
                    Password = registration.Password
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return RedirectToAction(nameof(Registration));
        }
    }
}
