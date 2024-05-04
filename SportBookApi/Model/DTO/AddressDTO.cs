using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Municupality { get; set; }
        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }
    }
}
