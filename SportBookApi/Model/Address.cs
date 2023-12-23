using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model
{
    public class Address
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
