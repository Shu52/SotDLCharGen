using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SotDLCharGen.Models;

namespace SotDLCharGen.Controllers
{
    public class HomeController : Controller
    {
        //This is controller for the home view. Do not delete.
        public IActionResult Index()
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
