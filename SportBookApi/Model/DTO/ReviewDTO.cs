using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string WrittenReview { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? FacilityId { get; set; }
    }
}
