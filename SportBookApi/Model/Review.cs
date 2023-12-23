using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string WrittenReview {  get; set; }
        public int? UserId { get; set; }
        public int? FacilityId { get; set; }
        public User User { get; set; } = new();
        public Facility Facility { get; set; } = new();
    }
}
