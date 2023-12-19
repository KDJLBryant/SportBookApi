using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using SportBookApi.Model;

namespace SportBookApi.Data
{
    public class BookingContext  : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships here
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Facility);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.SportType);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Facility)
                .WithMany(f => f.Reviews)
                .HasForeignKey(r => r.FacilityId);

            modelBuilder.Entity<Facility>()
                .HasMany(f => f.SportTypes);

            modelBuilder.Entity<Facility>()
                .HasOne(f => f.Address);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithMany(b => b.Users)
                .UsingEntity(j => j.ToTable("UserBookings"));

            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Kyle",
                        LastName = "Bryant",
                        Age = 21,
                        SocialSecNumber = 2403024,
                        Flag = 1,
                        AddressId = 1,
                    }
                );
            modelBuilder.Entity<SportType>().HasData(
                    new SportType
                    {
                        Id = 1,
                        Name = "Football" 
                    }
                );
            modelBuilder.Entity<Review>().HasData(
                    new Review
                    {
                        Id = 1,
                        WrittenReview = "Very Good!",
                        UserId = 1,
                        FacilityId = 1,
                    }
                );
            modelBuilder.Entity<Facility>().HasData(
                    new Facility
                    {
                        Id = 1,
                        Name = "Sport Place",
                        AddressId = 1,
                    }
                );
            modelBuilder.Entity<Booking>().HasData(
                    new Booking
                    {
                        Id = 1,
                        Date = DateTime.Now,
                        Duration = 30,
                        FacilityId = 1,
                        SportTypeId = 1
                    }
                );
            modelBuilder.Entity<Address>().HasData(
                    new Address
                    {
                        Id = 1,
                        Street = "Skutavogur",
                        City = "Reykjavik",
                        Municupality = "Capital",
                        ZipCode = "104"
                    }
                );
        }

        /*
        public static void SeedData(BookingContext dbContext)
        {
            // Ensure the database is created
            dbContext.Database.EnsureCreated();

            // Create instances of entities
            Address a1 = new Address
            {
                Street = "Skútavogur",
                City = "Reykjavik",
                Municupality = "Capital",
                ZipCode = "104"
            };

            Booking b1 = new Booking
            {
                Date = DateTime.Now,
                Duration = 30,
            };

            Facility f1 = new Facility
            {
                Name = "Someplace",
            };

            Review r1 = new Review
            {
                WrittenReview = "Very good",
            };

            SportType sT1 = new SportType
            {
                Name = "Football",
            };

            User u1 = new User
            {
                FirstName = "Kyle",
                LastName = "Bryant",
                Age = 21,
                SocialSecNumber = 240302,
            };

            // Establish relationships
            b1.Facility = f1;
            b1.SportType = sT1;
            b1.Users.Add(u1);

            f1.Address = a1;
            f1.SportTypes.Add(sT1);
            f1.Reviews.Add(r1);

            r1.User = u1;
            r1.Facility = f1;

            u1.Address = a1;
            u1.Bookings.Add(b1);
            u1.Reviews.Add(r1);

            // Add entities to DbContext
            dbContext.AddRange(a1, b1, f1, r1, sT1, u1);

            // Save changes to the database
            dbContext.SaveChanges();
        }
        */


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SportBookDB");
        }
    }
}
