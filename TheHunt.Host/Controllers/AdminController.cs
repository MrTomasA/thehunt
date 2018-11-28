using Microsoft.AspNetCore.Mvc;
using TheHunt.Host.Models;

namespace TheHunt.Host.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(new BaseIndexViewModel("angularApp"));
        }
    }
}