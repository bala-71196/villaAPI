using System.ComponentModel.DataAnnotations;

namespace villaAPI.Model.DTO
{
    public class villaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
