using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class UserDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public int? AddressId { get; set; }
    }
}
