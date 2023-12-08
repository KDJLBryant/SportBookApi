namespace SportBookApi.Model.DTO
{
    public class ReviewDTO
    {
        public string WrittenReview { get; set; }
        public User User { get; set; }
        public Facility Facility { get; set; }
    }
}
