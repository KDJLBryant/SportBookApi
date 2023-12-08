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
/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasMany(t => t.Users)
                .WithMany(s => s.Bookings)
                .UsingEntity<Dictionary<object, object>>(
                    "BookingUser", 
                    x => x.HasOne<User>().WithMany().OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne<Teacher>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );
        }
*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SportBookDB");
        }
    }
}
