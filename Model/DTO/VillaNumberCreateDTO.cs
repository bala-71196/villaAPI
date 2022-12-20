using System.ComponentModel.DataAnnotations;

namespace villaAPI.Model.DTO
{
    public class VillaNumberCreateDTO
    {

        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
