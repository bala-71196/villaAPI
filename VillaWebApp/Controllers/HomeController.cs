using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Villa_Utilities;
using VillaWebApp.Model;
using VillaWebApp.Model.DTO;
using VillaWebApp.Models;
using VillaWebApp.Services.IServices;

namespace VillaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public HomeController(IVillaService villaService, IMapper mapper)
        {
            this._villaService = villaService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<villaDTO> villaList = new();
            var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                villaList = JsonConvert.DeserializeObject<List<villaDTO>>(Convert.ToString(response.Result));
            }

            return View(villaList);
        }
    }
}