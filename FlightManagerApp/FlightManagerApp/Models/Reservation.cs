using System;
using System.Collections.Generic;

namespace FlightManagerApp.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Egn { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public string TicketType { get; set; } = null!;

    public int FlightId { get; set; }

    public virtual Flight Flight { get; set; } = null!;
}
