using Microsoft.AspNetCore.Mvc;
using TheHunt.Host.Models;

namespace TheHunt.Host.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            return View(new BaseIndexViewModel("angularApp"));
        }

        public IActionResult Login()
        {
            return View(new BaseIndexViewModel("angularApp"));
        }
    }
}