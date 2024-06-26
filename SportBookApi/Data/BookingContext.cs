﻿using Microsoft.AspNetCore.Server.IIS.Core;
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
            if (DbContext.Addresses.FirstOrDefault(x => x.Id == 1) == null)
            {
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
                    Duration = 30,
                };
                Booking b2 = new Booking
                {
                    Duration = 20,
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
                User u2 = new User
                {
                    FirstName = "Jim",
                    LastName = "Mgee",
                    Age = 55,
                    SocialSecNumber = 546525,
                };

                // Establish relationships
                b1.Facility = f1;
                b1.SportType = sT1;
                b1.User = u1;
                b2.Facility = f1;
                b2.SportType = sT1;
                b2.User = u2;

                f1.Address = a1;
                f1.SportTypes.Add(sT1);
                f1.Reviews.Add(r1);

                r1.User = u1;
                r1.Facility = f1;

                u1.Address = a1;
                u1.Bookings.Add(b1);
                u1.Reviews.Add(r1);
                u2.Address = a1;
                u2.Bookings.Add(b2);

                // Add entities to DbContext
                DbContext.AddRange(a1, b1, b2, f1, r1, sT1, u1, u2);

                // Save changes to the database
                DbContext.SaveChanges();
            }
        }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SportBookDB");
        }
    }
}
