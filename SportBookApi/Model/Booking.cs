namespace SportBookApi.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Date {  get; set; }
        public int Duration { get; set; }
        public int FacilityId { get; set; }
        public int SportTypeId { get; set; }
        public Facility Facility { get; set; }
        public SportType SportType { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
