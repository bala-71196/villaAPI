using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace villaAPI.Model
{
    public class VillaNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }
        [ForeignKey("VillaID")]
        public int VillaID { get; set; }
        public villa Villa { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
