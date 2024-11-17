 using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;

        public AdminController(IProductsRepository productRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productRepository = productRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Orders()
        {
            List<Order> orders = ordersRepository.GetAllOrders();
            return View(orders);
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            List<Role> roles = rolesRepository.GetAllRoles();
            return View(roles);
        }
        public IActionResult Products()
        {
            List<Product> products = productRepository.GetAll();
            return View(products);
        }
        public IActionResult ShowOrderDetails(string orderId)
        {
            Order order = ordersRepository.TryGetById(new Guid(orderId));
            return View(order);
        }
        public IActionResult EditOrder(Guid orderId, OrderStatusesEnum status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productRepository.Add(product);
            return RedirectToAction("Products");
        }
        public IActionResult RemoveProduct(int productId)
        {
            var product = productRepository.TryGetById(productId);
            productRepository.Remove(product);
            return RedirectToAction("Products");
        }
        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            Product product = productRepository.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productRepository.Update(product);
            return RedirectToAction("Products");
        }
        public IActionResult RemoveRole(string roleName)
        {
            var product = rolesRepository.TryGetByName(roleName);
            rolesRepository.Remove(roleName);
            return RedirectToAction("Roles");
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "This role is already exist");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
    }
}
