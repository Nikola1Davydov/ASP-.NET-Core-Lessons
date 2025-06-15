using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;
        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }
        public IActionResult Index()
        {
            List<UserAccount> users = usersManager.GetAll();
            return View(users);
        }
        public IActionResult Details(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound("Username cannot be null or empty");
            }
            UserAccount user = usersManager.TryGetByName(name);
            if (user == null)
            {
                return NotFound($"User with username '{name}' not found");
            }
            return View(user);
        }
        public IActionResult ChangePassport(string name)
        {
            ChangePassport changePassport = new ChangePassport()
            {
                UserName = name
            };
            return View(changePassport);
        }
        [HttpPost]
        public IActionResult ChangePassport(ChangePassport changePassport)
        {
            if (changePassport.UserName == changePassport.Password)
            {
                ModelState.AddModelError("", "Name and password should not be the same ");
            }
            if (ModelState.IsValid)
            {
                usersManager.ChangePasswort(changePassport.UserName, changePassport.Password);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassport));
        }
        public IActionResult Delete(string name)
        {
            UserAccount user = usersManager.TryGetByName(name);
            usersManager.Delete(name);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(string name)
        {
            UserAccount user = usersManager.TryGetByName(name);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(UserAccount userAccount)
        {

            usersManager.Edit(userAccount);
            return RedirectToAction(nameof(Index));
        }
    }
}
