using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheHunt.Host.Models;

namespace TheHunt.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View(new AboutViewModel());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View(new ContactViewModel());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}