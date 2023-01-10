using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VillaWebApp.Model.DTO;

namespace VillaWebApp.Models.VM
{
    public class VillaNumberCreateVM
    {
        public VillaNumberCreateVM()
        {
            VillaNumber = new VillaNumberCreateDTO();
        }
        public VillaNumberCreateDTO VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; }

    }
}
