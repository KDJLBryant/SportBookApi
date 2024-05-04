using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model.DTO
{
    public class SportTypeDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
