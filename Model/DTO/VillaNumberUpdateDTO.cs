using System.ComponentModel.DataAnnotations;

namespace villaAPI.Model.DTO
{
    public class VillaNumberUpdateDTO
    {

        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
