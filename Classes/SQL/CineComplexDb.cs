using CineComplex.Models;
using CineComplex.Models.CineComplex.Models;
using CineComplex.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpCompress.Common;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineComplex.Classes.SQL
{
    public class CineComplexDb : DbContext
    {
        private readonly DbConnection _connection;

        /// <summary>
        /// Migration tools needs parameterless constructor because it instantiates while doing migration process
        /// dotnet ef migrations add CreateAuthTable
        /// dotnet ef database update
        /// </summary>
        public CineComplexDb() { }

        public CineComplexDb(DbConnection connection)
        {
            _connection = connection;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connection != null)
            {
                optionsBuilder.UseSqlite(_connection);
            }
            else
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string dbPath = Path.Combine(basePath, "CineComplexDatabase.db");

                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-one with UserProfile
            modelBuilder.Entity<User>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50); // Name is required, max length 50 
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50); // Email is required, max length 50 
                entity.Property(e => e.Contact).IsRequired().HasMaxLength(15); // Contact is required, max length 15

                // Set unique constraints
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Contact).IsUnique();

                // Enum mapping (AccountStatus will be stored as int by default)
                entity.Property(e => e.Status)
                      .IsRequired();

                // Relationships
                entity.HasOne(e => e.UserProfile)
                  .WithOne(up => up.UserAccount)
                  .HasForeignKey<User>(up => up.Id)
                  .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.Id);

                //one-to-one with User
                entity.HasOne(up => up.UserAccount)
                      .WithOne(u => u.UserProfile)
                      .HasForeignKey<UserProfile>(up => up.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                //one-to-many with BankAccount
                entity.HasMany(up => up.BankDetails)
                      .WithOne(ba => ba.AccountProfile)
                      .HasForeignKey(ba => ba.UserProfileId);

                //one-to-many with Address
                entity.HasMany(up => up.AddressDetails)
                      .WithOne(ba => ba.AccountProfile)
                      .HasForeignKey(ba => ba.AccountProfileId);
            });

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.PrivilegeLevel).IsRequired();

            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Token).IsRequired().HasMaxLength(200);
                entity.Property(e => e.LoginTimestamp).IsRequired();
                entity.Property(e => e.ExpirationTimestamp).IsRequired();

                //one-to-one with User
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.Id); // Setting primary key

                entity.Property(e => e.AccountNumber)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.GSTNumber)
                      .HasMaxLength(15);

                entity.Property(e => e.BankName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.IFSCNumber)
                      .IsRequired()
                      .HasMaxLength(11);

                entity.Property(e => e.AccountHolderName)
                      .IsRequired()
                      .HasMaxLength(100);

                //one-to-many with UserProfile
                entity.HasOne(up => up.AccountProfile)
                      .WithMany(ba => ba.BankDetails)
                      .HasForeignKey(ba => ba.UserProfileId);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id); // Configure primary key

                entity.Property(e => e.Area)
                      .IsRequired()
                      .HasMaxLength(100); // Example configuration

                entity.Property(e => e.StreetName)
                      .IsRequired()
                      .HasMaxLength(100); // Example configuration

                entity.Property(e => e.City)
                      .IsRequired()
                      .HasMaxLength(50); // Example configuration

                entity.Property(e => e.State)
                      .IsRequired()
                      .HasMaxLength(50); // Example configuration

                entity.Property(e => e.Country)
                      .IsRequired()
                      .HasMaxLength(15); // Example configuration

                entity.Property(e => e.PinCode)
                      .IsRequired()
                      .HasMaxLength(10); // Example configuration

                entity.Property(e => e.BuildingDetails)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.OtherDetails)
                      .IsRequired()
                      .HasMaxLength(50);

                //one-to-many with UserProfile
                entity.HasOne(up => up.AccountProfile)
                      .WithMany(ba => ba.AddressDetails)
                      .HasForeignKey(ba => ba.AccountProfileId);

            });

            modelBuilder.Entity<Theatre>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.OperatorName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CineplexName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired(); // Security: Store hashed passwords
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Contact).HasMaxLength(15);
                entity.Property(e => e.NumberOfTheatres).IsRequired();

                // One-to-one relationship with UserProfile
                entity.HasOne(e => e.AccountProfile)
                      .WithMany(up => up.Multiplexes)
                      .HasForeignKey(e => e.AccountProfileId);

            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Status)
                      .IsRequired();

                entity.Property(t => t.PurchaseDate)
                      .IsRequired();

                // Relationships
                entity.HasOne(t => t.Booking)
                      .WithMany(b => b.Tickets)
                      .HasForeignKey(t => t.BookingId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.SeatBooked)
                      .WithMany(s => s.Tickets)
                      .HasForeignKey(t => t.SeatId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.ShowBooked)
                      .WithMany(sh => sh.TicketsOfTheShow)
                      .HasForeignKey(t => t.ShowId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tickets)
                      .HasForeignKey(t => t.UserProfileId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.HasKey(s => s.Id);

                // Required properties
                entity.Property(s => s.PlatinumSeatRate)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(s => s.GoldSeatRate)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(s => s.SilverSeatRate)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(s => s.StartDate)
                      .IsRequired();

                entity.Property(s => s.EndDate)
                      .IsRequired();

                // Relationship: Show <-> Movie (many shows per movie)
                entity.HasOne(s => s.ShowMovie)
                      .WithMany(m => m.MovieShows)
                      .HasForeignKey(s => s.MovieId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Show <-> Auditorium (many shows per auditorium)
                entity.HasOne(s => s.HostingAuditorium)
                      .WithMany(a => a.AllShowsOfThisAuditorium)
                      .HasForeignKey(s => s.AuditoriumId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Show <-> Tickets (one show has many tickets)
                entity.HasMany(s => s.TicketsOfTheShow)
                      .WithOne(t => t.ShowBooked)
                      .HasForeignKey(t => t.ShowId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Capacity)
                      .IsRequired();

                // Relationship: Auditorium <-> Theatre (many auditoriums per theatre)
                entity.HasOne(a => a.CineComplexTheatre)
                      .WithMany(t => t.Auditoriums)
                      .HasForeignKey(a => a.TheatreId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Auditorium <-> Seats (one auditorium has many seats)
                entity.HasMany(a => a.SeatsInAudi)
                      .WithOne(s => s.AuditoriumOfTheTheatre)
                      .HasForeignKey(s => s.AuditoriumId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Auditorium <-> Shows (one auditorium hosts many shows)
                entity.HasMany(a => a.AllShowsOfThisAuditorium)
                      .WithOne(sh => sh.HostingAuditorium)
                      .HasForeignKey(sh => sh.AuditoriumId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.SeatCode)
                      .IsRequired()
                      .HasMaxLength(10);

                entity.HasIndex(s => new { s.SeatCode, s.AuditoriumId })
                      .IsUnique();

                entity.Property(s => s.SeatAvailability)
                      .IsRequired();

                entity.Property(s => s.TypeOfSeat)
                      .IsRequired();

                entity.HasOne(s => s.AuditoriumOfTheTheatre)
                      .WithMany(a => a.SeatsInAudi)
                      .HasForeignKey(s => s.AuditoriumId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.Tickets)
                      .WithOne(t => t.SeatBooked)
                      .HasForeignKey(t => t.SeatId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.Id);

                // Amount column with precision
                entity.Property(p => p.Amount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                // Transaction reference
                entity.Property(p => p.TransactionReference)
                      .HasMaxLength(100);

                // Payment date
                entity.Property(p => p.PaymentDate)
                      .IsRequired();

                // Enum mapping: store as string for readability
                entity.Property(p => p.Method)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(p => p.Status)
                      .HasConversion<string>()
                      .IsRequired();

                // Relationship: Payment <-> Booking (one booking has one payment)
                entity.HasOne(p => p.Booking)
                      .WithOne(b => b.Payment) // add Payment navigation in Booking
                      .HasForeignKey<Payment>(p => p.BookingId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Payment <-> UserProfile (one user can have many payments)
                entity.HasOne(p => p.UserProfile)
                      .WithMany(u => u.Payments) // add Payments navigation in UserProfile
                      .HasForeignKey(p => p.UserProfileId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.Id);

                // Status enum stored as string for readability
                entity.Property(b => b.Status)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(b => b.CreatedAt)
                      .IsRequired();

                // Relationship: Booking <-> UserProfile (many bookings per user profile)
                entity.HasOne(b => b.User)
                      .WithMany(u => u.Bookings)   // Add ICollection<Booking> in UserProfile
                      .HasForeignKey(b => b.UserProfileId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Booking <-> Show (many bookings per show)
                entity.HasOne(b => b.Show)
                      .WithMany(s => s.Bookings)  // Add ICollection<Booking> in Show
                      .HasForeignKey(b => b.ShowId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Booking <-> Tickets (one booking has many tickets)
                entity.HasMany(b => b.Tickets)
                      .WithOne(t => t.Booking)
                      .HasForeignKey(t => t.BookingId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Booking <-> Payment (one booking has one payment)
                entity.HasOne(b => b.Payment)
                      .WithOne(p => p.Booking)    // Add Booking navigation in Payment
                      .HasForeignKey<Payment>(p => p.BookingId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }

    }
}