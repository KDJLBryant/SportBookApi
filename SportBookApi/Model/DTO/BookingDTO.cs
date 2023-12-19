namespace SportBookApi.Model.DTO
{
    public class BookingDTO
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int? FacilityId { get; set; }
        public int? SportTypeId { get; set; }
    }
}
