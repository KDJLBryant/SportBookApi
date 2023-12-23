using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int SocialSecNumber { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}
