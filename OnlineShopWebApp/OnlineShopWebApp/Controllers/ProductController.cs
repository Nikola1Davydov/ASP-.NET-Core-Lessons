using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;
using System.Xml;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}#
       

        public string Index(string id)
        {
            List<Waren> listWaren = new List<Waren>();
            for (int i = 1; i < 4; i++)
            {
                listWaren.Add(new Waren("Id"+i, "Name"+i, "Cost"+i));
            }
            //var test = listWaren.Select(x => x.Info());
            var test = listWaren.First(x => x.Id == id);
            return String.Join(Environment.NewLine, test.Info());
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
