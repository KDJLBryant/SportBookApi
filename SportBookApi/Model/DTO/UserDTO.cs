using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class UserDTO
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
        public List<Booking> Bookings { get; set; }
    }
}
