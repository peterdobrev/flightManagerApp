using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightManagerApp.Models;

namespace FlightManagerApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly FlightManagerDbContext _context;

        public ReservationsController(FlightManagerDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction("Index", "Home");
            }
            var flightManagerDbContext = _context.Reservations;
            return View(await flightManagerDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,FirstName,MiddleName,LastName,Egn,Email,PhoneNumber,Nationality,TicketType,FlightId")] Reservation reservation)
        {
            var flight = _context.Flights.FirstOrDefault(x=>x.FlightId == reservation.FlightId);
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId", reservation.FlightId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId", reservation.FlightId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,FirstName,MiddleName,LastName,Egn,Email,PhoneNumber,Nationality,TicketType,FlightId")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "FlightId", "FlightId", reservation.FlightId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'FlightManagerDbContext.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.ReservationId == id)).GetValueOrDefault();
        }

        [HttpGet]
        public IActionResult ChoosePassengers(int? flightId)
        {
            PassengerChooserModel model = new();
            model.FlightId = (int)flightId;
            return View("_PassengerChooser", model);
        }

        [HttpPost]
        public IActionResult DisplayPassengerForms(PassengerChooserModel model)
        {
            List<PassengerModel> passengers = new List<PassengerModel>();
            for (int i = 0; i < model.Count; i++)
            {
                passengers.Add(new PassengerModel() { FlightId = model.FlightId, Email = model.Email });;
            }
            return PartialView("_PassengersForm", passengers);
        }

        [HttpPost]
        public IActionResult MakeReservation(List<PassengerModel> passengers)
        {
            foreach (var passenger in passengers)
            {
                Reservation reservation = new Reservation()
                {
                    Email = passenger.Email,
                    FlightId = passenger.FlightId,
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    MiddleName = passenger.MiddleName,
                    Egn = passenger.Egn,
                    TicketType = passenger.TicketType,
                    Nationality = passenger.Nationality,
                    PhoneNumber = passenger.TelephoneNumber
                };
                _context.Reservations.Add(reservation);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
