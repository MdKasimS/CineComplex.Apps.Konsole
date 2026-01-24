using CineComplex.Models;
using CineComplex.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public DbSet<Movie> Movies { get; set; }

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

            // Configuring CinePlex entity
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


        }

    }
}