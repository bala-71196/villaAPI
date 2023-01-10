using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaWebApp.Model.DTO
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }

        public int VillaID { get; set; }
        public villaDTO Villa { get; set; }
    }
}
