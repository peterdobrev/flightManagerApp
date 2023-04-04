using Microsoft.EntityFrameworkCore;

namespace FlightManager.Data
{
    public class FlightManagerDBContext : DbContext
    {
        public FlightManagerDBContext(DbContextOptions<FlightManagerDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<Flight>()
                .HasKey(f => f.FlightID);

            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationID);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Reservations)
                .WithOne(r => r.Flight)
                .HasForeignKey(r => r.FlightID);
        }
    }
}
