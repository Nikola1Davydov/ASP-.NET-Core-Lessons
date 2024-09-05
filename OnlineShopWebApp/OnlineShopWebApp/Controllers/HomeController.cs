using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;
using System.Xml;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}#
       

        public string Index()
        {
            List<Waren> listWaren = new List<Waren>();
            for (int i = 1; i < 4; i++)
            {
                listWaren.Add(new Waren("Id"+i, "Name"+i, "Cost"+i));
            }
            var test = listWaren.Select(x => x.Info());
            return String.Join(Environment.NewLine, test);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
