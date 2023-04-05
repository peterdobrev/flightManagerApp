using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightManagerApp.Models;

public partial class FlightManagerDbContext : DbContext
{
    public FlightManagerDbContext()
    {
    }

    public FlightManagerDbContext(DbContextOptions<FlightManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=FlightManagerDB;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flight__8A9E148EAAF2172E");

            entity.ToTable("Flight");

            entity.HasIndex(e => e.PlaneNumber, "UQ__Flight__4B2DC94C14631165").IsUnique();

            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.ArrivalDateTime).HasColumnType("datetime");
            entity.Property(e => e.ArrivalLocation).HasMaxLength(100);
            entity.Property(e => e.DepartureDateTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureLocation).HasMaxLength(100);
            entity.Property(e => e.PilotName).HasMaxLength(100);
            entity.Property(e => e.PlaneNumber).HasMaxLength(100);
            entity.Property(e => e.PlaneType).HasMaxLength(100);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F048469099F");

            entity.ToTable("Reservation");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Reservat__85FB4E38BE66E9BA").IsUnique();

            entity.HasIndex(e => e.Egn, "UQ__Reservat__C190274669C88622").IsUnique();

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.Egn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EGN");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TicketType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC7684D7F4");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E417ED9D71").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E38E4FCDA7B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534EFFD64A2").IsUnique();

            entity.HasIndex(e => e.Egn, "UQ__User__C19027465FBCEB18").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Egn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EGN");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
