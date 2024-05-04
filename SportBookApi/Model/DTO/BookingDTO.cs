using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        [Required]
        public int Duration { get; set; }
        public int? FacilityId { get; set; }
        public int? SportTypeId { get; set; }
        public int? UserId { get; set; }
    }
}
