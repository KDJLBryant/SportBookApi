namespace SportBookApi.Model.DTO
{
    public class ReviewDTO
    {
        public string WrittenReview { get; set; }
        public int? UserId { get; set; }
        public int? FacilityId { get; set; }
        public User User { get; set; } = new();
        public Facility Facility { get; set; } = new();
    }
}
