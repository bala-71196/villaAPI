using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using Villa_Utilities;
using VillaWebApp.Model;
using VillaWebApp.Model.DTO;
using VillaWebApp.Models.VM;
using VillaWebApp.Services;
using VillaWebApp.Services.IServices;

namespace VillaWebApp.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaService villaService, IVillaNumberService villaNumberService,IMapper mapper)
        {
            this._villaNumberService = villaNumberService;
            this._villaService = villaService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> villaList = new();
            var response = await _villaNumberService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if(response != null && response.IsSuccess)
            {
                villaList = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }

            return View(villaList);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberVM = new();
            var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if ( response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<villaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                    ); ;
            }

            return View(villaNumberVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber, HttpContext.Session.GetString(SD.SessionToken));

                if (response.IsSuccess && response != null)
                {
                    TempData["success"] = "VillaNumber Created Successfully";

                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if(response.ErrorMessages.Count > 0) {
                        ModelState.AddModelError("ErrorMessages",response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            var resp = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (resp.IsSuccess && resp != null)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<villaDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                    ); ;
            }
            TempData["error"] = "Error Encountered";

            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVillaNumber(int villaNo)
        {
            VillaNumberUpdateVM villaNumberVM = new();
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNo, HttpContext.Session.GetString(SD.SessionToken));

            if (response.IsSuccess && response != null)
            {
                VillaNumberDTO content = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                villaNumberVM.VillaNumber = _mapper.Map<VillaNumberUpdateDTO>(content);
            }
            var resp = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp.IsSuccess && resp != null)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<villaDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                    );
                
                return View(villaNumberVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<APIResponse>(model.VillaNumber, HttpContext.Session.GetString(SD.SessionToken));

                if (response.IsSuccess && response != null)
                {
                    TempData["success"] = "VillaNumber Updated Successfully";

                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            var resp = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (resp.IsSuccess && resp != null)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<villaDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                    ); ;
            }
            TempData["error"] = "Error Encountered";

            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVillaNumber(int villaNo)
        {
            VillaNumberDeleteVM villaNumberVM = new();
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNo, HttpContext.Session.GetString(SD.SessionToken));

            if (response.IsSuccess && response != null)
            {
                VillaNumberDTO content = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                villaNumberVM.VillaNumber = _mapper.Map<VillaNumberDTO>(content);
            }
            var resp = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp.IsSuccess && resp != null)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<villaDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                    );
                return View(villaNumberVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM deleteVilla)
        {
            var response = await _villaNumberService.DeleteAsync<APIResponse>(deleteVilla.VillaNumber.VillaNo, HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "VillaNumber Deleted Successfully";

                return RedirectToAction(nameof(IndexVillaNumber));
            }
            TempData["error"] = "Error Encountered";

            return View(deleteVilla);
        }
    }
}
