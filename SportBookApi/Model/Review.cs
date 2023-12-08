namespace SportBookApi.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string WrittenReview {  get; set; }
        public int UserId { get; set; }
        public int FacilityId { get; set; }
        public User User { get; set; }
        public Facility Facility { get; set; }
    }
}
