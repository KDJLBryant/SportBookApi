namespace SportBookApi.Model.DTO
{
    public class BookingDTO
    {
        public int Date { get; set; }
        public int Duration { get; set; }
        public Facility Facility { get; set; }
        public SportType SportType { get; set; }
        public List<User> users { get; set; }
    }
}
