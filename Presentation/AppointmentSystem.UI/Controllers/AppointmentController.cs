using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.UI.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
