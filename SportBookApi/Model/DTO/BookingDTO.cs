using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class BookingDTO
    {
        [Required]
        public int Duration { get; set; }
        [Required]
        public int? FacilityId { get; set; }
        [Required]
        public int? SportTypeId { get; set; }
    }
}
