using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Villa_Utilities;
using VillaWebApp.Model;
using VillaWebApp.Model.DTO;
using VillaWebApp.Services.IServices;

namespace VillaWebApp.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaController(IVillaService villaService,IMapper mapper)
        {
            this._villaService = villaService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<villaDTO> villaList = new();
            var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if(response != null && response.IsSuccess)
            {
                villaList = JsonConvert.DeserializeObject<List<villaDTO>>(Convert.ToString(response.Result));
            }

            return View(villaList);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));

                if (response.IsSuccess && response != null)
                {
                    TempData["success"] = "Villa Created Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error Encountered";

            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));

            if(response.IsSuccess && response != null)
            {
                var content = JsonConvert.DeserializeObject<villaDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaUpdateDTO>(content));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO villaUpdateDTO)
        {
            if (ModelState.IsValid) { 
                var response = await _villaService.UpdateAsync<APIResponse>(villaUpdateDTO, HttpContext.Session.GetString(SD.SessionToken));

                if(response!= null && response.IsSuccess)
                {
                    TempData["success"] = "Villa Updated Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error Encountered";

            return View(villaUpdateDTO);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));

            if (response.IsSuccess && response != null)
            {
                var model = JsonConvert.DeserializeObject<villaDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(villaDTO deleteVilla)
        {
            var response = await _villaService.DeleteAsync<APIResponse>(deleteVilla.Id, HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa Deleted Successfully";
                return RedirectToAction(nameof(IndexVilla));
            }

            TempData["error"] = "Error Encountered";
            return View(deleteVilla);
        }
    }
}
