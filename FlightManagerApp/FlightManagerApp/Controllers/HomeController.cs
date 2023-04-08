using FlightManagerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FlightManagerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FlightManagerDbContext _context;


        public HomeController(ILogger<HomeController> logger, FlightManagerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return _context.Flights != null ?
                          View(_context.Flights.Where(x => x.DepartureDateTime.CompareTo(DateTime.Today) >= 0 && (x.BusinessClassCapacity > 0 || x.PassengerCapacity > 0)).ToList()) :
                          Problem("Entity set 'FlightManagerDbContext.Flights'  is null.");
        }

        public IActionResult Privacy()
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