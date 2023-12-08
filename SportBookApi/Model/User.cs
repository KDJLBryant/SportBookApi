namespace SportBookApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int SocialSecNumber { get; set; }
        public int Flag { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public List<Review> Reviews { get; set; } = new();
    }
}
