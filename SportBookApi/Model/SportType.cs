using System.ComponentModel.DataAnnotations;

namespace SportBookApi.Model
{
    public class SportType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
