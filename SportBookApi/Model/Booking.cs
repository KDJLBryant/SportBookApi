using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model
{
    // Made nullable and unRequired FK's due to cascade deletion errors!
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Date {  get; } = DateTime.Now.Date;
        [Required]
        public int Duration { get; set; }
        public int? FacilityId { get; set; }
        public int? SportTypeId { get; set; }
        public int? UserId { get; set; }
        public Facility Facility { get; set; } = new();
        public SportType SportType { get; set; } = new();
        public User User { get; set; } = new();
    }
}
