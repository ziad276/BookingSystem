using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
