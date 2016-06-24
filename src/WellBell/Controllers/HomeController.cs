using Microsoft.AspNetCore.Mvc;

namespace WellBell.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
