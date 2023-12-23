using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class SportTypeDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
