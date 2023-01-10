using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VillaWebApp.Model.DTO;

namespace VillaWebApp.Models.VM
{
    public class VillaNumberUpdateVM
    {
        public VillaNumberUpdateVM()
        {
            VillaNumber = new VillaNumberUpdateDTO();
        }
        public VillaNumberUpdateDTO VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; }

    }
}
