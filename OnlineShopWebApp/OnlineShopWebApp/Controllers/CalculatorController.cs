using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double a, double b, string c = "+")
        {
            string possibleSymbols = "+-*/";
            if (!possibleSymbols.Contains(c)) return "ERROR";
            if (c.Equals("-")) return $"{a} - {b} = {a - b}";
            if (c.Equals("*")) return $"{a} * {b} = {a * b}";
            return $"{a} + {b} = {a + b}";
            
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
