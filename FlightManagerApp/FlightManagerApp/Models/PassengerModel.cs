namespace FlightManagerApp.Models
{
    public class PassengerModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Egn { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Nationality { get; set; }
        public string TicketType { get; set; }
        public int FlightId { get; set; }

        public PassengerModel()
        {

        }
    }
}
