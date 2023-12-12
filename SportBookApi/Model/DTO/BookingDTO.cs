namespace SportBookApi.Model.DTO
{
    public class BookingDTO
    {
        public int Date { get; set; }
        public int Duration { get; set; }
        public int FacilityId { get; set; }
        public int SportTypeId { get; set; }
        public Facility Facility { get; set; } = new();
        public SportType SportType { get; set; } = new();
    }
}
