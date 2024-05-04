using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class FacilityDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int? AddressId { get; set; }
    }
}
