using FlightManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManagerApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly FlightManagerDbContext _dbContext;

        public LoginController(FlightManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return View();
            }
            else return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Check if the username and password match a user in the database
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // If the user is found, set a session variable to indicate that the user is authenticated
                HttpContext.Session.SetString("IsAuthenticated", "true");

                //Save his username so that we can print it later: Hello, {User}
                HttpContext.Session.SetString("Username", user.Username);


                //Check if admin and save result
                if(user.Role == "admin")
                {
                    HttpContext.Session.SetString("IsAdmin", "true");
                }

                // Redirect the user to the Home/Index action
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
