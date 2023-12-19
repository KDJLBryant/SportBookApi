using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using SportBookApi.Model;
using System.Reflection.Metadata;

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

        
        public static void SeedData()
        {
            BookingContext DbContext = new BookingContext();
            // Ensure the database is created
            DbContext.Database.EnsureCreated();

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
            DbContext.AddRange(a1, b1, f1, r1, sT1, u1);

            // Save changes to the database
            DbContext.SaveChanges();
        }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SportBookDB");
        }
    }
}
