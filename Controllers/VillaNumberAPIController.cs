using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;
using villaAPI.Data;
using villaAPI.Model;
using villaAPI.Model.DTO;
using villaAPI.Repository.IRepository;

namespace villaAPI.Controllers
{
    [ApiController]
    [Route("api/VillaNumberAPI")]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public VillaNumberAPIController(IVillaNumberRepository dbVillaNumber, IMapper mapper)
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<VillaNumber> villaNoModel = await _dbVillaNumber.GetAllAsync();
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

        [HttpGet("{VillaNo:int}", Name = "GetVillaDetailsByVillaNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetVilla(int VillaNo)
        {
            try
            {
                if (VillaNo == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == VillaNo);

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
                //if (await _dbVillaNumber.GetAsync(u => u.Name.ToLower() == postData.Name.ToLower()) != null)
                //{
                //    ModelState.AddModelError("Error", "villa already present");
                //    return BadRequest(ModelState);
                //}

                var villaModel = _mapper.Map<VillaNumber>(postData);
                villaModel.CreatedDateTime = DateTime.Now;
                await _dbVillaNumber.CreateAsync(villaModel);
                await _dbVillaNumber.SaveAsync();

                _response.Result = villaModel;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVillaDetailsByVillaNo", new { VillaNo = villaModel.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int VillaNo)
        {
            try
            {
                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == VillaNo);

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

        [HttpPut("{VillaNo:int}", Name = "UpdateVillaByVillaNo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int VillaNo, [FromBody] VillaNumberUpdateDTO updateVilla)
        {
            try
            {
                if (VillaNo == 0 || updateVilla == null || VillaNo != updateVilla.VillaNo)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villaModel = _mapper.Map<VillaNumber>(updateVilla);


                await _dbVillaNumber.UpdateAsync(villaModel);
                await _dbVillaNumber.SaveAsync();
                _response.Result = villaModel;
                _response.StatusCode = HttpStatusCode.OK;

                return CreatedAtRoute("GetVillaDetailsByVillaNo", new { VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }

        [HttpPatch("{id:int}", Name = "UpdatePartitalVillaByVillaNo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> PatchUpdate(int VillaNo, JsonPatchDocument<VillaNumberUpdateDTO> patchVilla)
        {
            try
            {
                if (patchVilla == null || VillaNo == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == VillaNo, false);

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
