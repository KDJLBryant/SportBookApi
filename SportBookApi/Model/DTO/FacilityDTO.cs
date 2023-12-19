namespace SportBookApi.Model.DTO
{
    public class FacilityDTO
    {
        public string Name { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; } = new();
        public List<SportType> SportTypes { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}
