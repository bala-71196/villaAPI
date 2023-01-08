using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Xml.Linq;
using villaAPI.Data;
using villaAPI.Model;
using villaAPI.Model.DTO;
using villaAPI.Repository.IRepository;

namespace villaAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/VillaNumber")]
    [ApiVersion("1.0")]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public VillaNumberAPIController(IVillaRepository dbVilla, IVillaNumberRepository dbVillaNumber, IMapper mapper)
        {
            _dbVillaNumber = dbVillaNumber;
            _dbVilla = dbVilla;
            _mapper = mapper;
            _response = new();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<VillaNumber> villaNoModel = await _dbVillaNumber.GetAllAsync(includeProperties: "Villa");
                _response.Result = _mapper.Map<IEnumerable<VillaNumberDTO>>(villaNoModel);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }

        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "version1", "v1" };
        }


        [Authorize(Roles = "admin")]
        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = false;
                    return NoContent();
                }
                _response.Result = _mapper.Map<VillaNumberDTO>(villa); ;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> PostVilla([FromBody] VillaNumberCreateDTO postData)
        {
            try
            {
                if (postData == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                if (await _dbVillaNumber.GetAsync(u => u.VillaNo == postData.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa is already present");
                    return BadRequest(ModelState);
                }

                if (await _dbVilla.GetAsync(u => u.Id == postData.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "VillaID is not present");
                    return BadRequest(ModelState);
                }

                var villaModel = _mapper.Map<VillaNumber>(postData);
                villaModel.CreatedDateTime = DateTime.Now;
                await _dbVillaNumber.CreateAsync(villaModel);
                await _dbVillaNumber.SaveAsync();

                _response.Result = villaModel;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVillaNumber", new { id = villaModel.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                await _dbVillaNumber.DeleteAsync(villa);
                await _dbVillaNumber.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaNumberUpdateDTO updateVilla)
        {
            try
            {
                if (id == 0 || updateVilla == null || id != updateVilla.VillaID)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                if (await _dbVilla.GetAsync(u => u.Id == updateVilla.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "VillaID is not present");
                    return BadRequest(ModelState);
                }

                var villaModel = _mapper.Map<VillaNumber>(updateVilla);


                await _dbVillaNumber.UpdateAsync(villaModel);
                await _dbVillaNumber.SaveAsync();
                _response.Result = villaModel;
                _response.StatusCode = HttpStatusCode.OK;

                return CreatedAtRoute("GetVillaNumber", new { id }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPatch("{id:int}", Name = "UpdatePartitalVillaByVillaNo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> PatchUpdate(int id, JsonPatchDocument<VillaNumberUpdateDTO> patchVilla)
        {
            try
            {
                if (patchVilla == null || id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == id, false);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villaUpdateModel = _mapper.Map<VillaNumberUpdateDTO>(villa);

                patchVilla.ApplyTo(villaUpdateModel, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var villaModel = _mapper.Map<VillaNumber>(villaUpdateModel);

                await _dbVillaNumber.UpdateAsync(villaModel);
                await _dbVillaNumber.SaveAsync();

                _response.Result = villaModel;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }
    }
}
