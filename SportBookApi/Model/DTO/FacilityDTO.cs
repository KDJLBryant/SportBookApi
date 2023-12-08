namespace SportBookApi.Model.DTO
{
    public class FacilityDTO
    {
        public string Name { get; set; }
        public User Owner { get; set; }
        public Address Address { get; set; }
        public List<SportType> SportTypes { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
