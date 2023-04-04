using Microsoft.AspNetCore.Mvc;

namespace FlightManagerApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
