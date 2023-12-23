using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class ReviewDTO
    {
        [Required]
        [MaxLength(255)]
        public string WrittenReview { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? FacilityId { get; set; }
    }
}
