using System;
using System.Collections.Generic;

namespace FlightManagerApp.Models;

public partial class Flight
{
    public int FlightId { get; set; }

    public string DepartureLocation { get; set; } = null!;

    public string ArrivalLocation { get; set; } = null!;

    public DateTime DepartureDateTime { get; set; }

    public DateTime ArrivalDateTime { get; set; }

    public string PlaneType { get; set; } = null!;

    public string PlaneNumber { get; set; } = null!;

    public string PilotName { get; set; } = null!;

    public int PassengerCapacity { get; set; }

    public int BusinessClassCapacity { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
