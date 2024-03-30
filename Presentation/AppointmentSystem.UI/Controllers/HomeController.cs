using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
