﻿using AutoMapper;
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
    [Route("api/villaAPI")]
    public class villaAPIController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public villaAPIController(IVillaRepository dbVilla, IMapper mapper)
        {
            _dbVilla = dbVilla;
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
                IEnumerable<villa> villaModel = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<IEnumerable<villaDTO>>(villaModel);
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

        [HttpGet("{id:int}", Name = "GetVilla")]
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

                var villa = await _dbVilla.GetAsync(u => u.Id == id);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = false;
                    return NoContent();
                }
                _response.Result = _mapper.Map<villaDTO>(villa); ;
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
        public async Task<ActionResult<APIResponse>> PostVilla([FromBody] VillaCreateDTO postData)
        {
            try
            {
                if (postData == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                if (await _dbVilla.GetAsync(u => u.Name.ToLower() == postData.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error", "villa already present");
                    return BadRequest(ModelState);
                }

                villa villaModel = _mapper.Map<villa>(postData);
                villaModel.CreatedDate = DateTime.Now;
                await _dbVilla.CreateAsync(villaModel);
                await _dbVilla.SaveAsync();

                _response.Result = villaModel;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = villaModel.Id }, _response);
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
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                var villa = await _dbVilla.GetAsync(u => u.Id == id);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                await _dbVilla.DeleteAsync(villa);
                await _dbVilla.SaveAsync();

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

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateVilla)
        {
            try
            {
                if (id == 0 || updateVilla == null || id != updateVilla.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                villa villaModel = _mapper.Map<villa>(updateVilla);


                await _dbVilla.UpdateAsync(villaModel);
                await _dbVilla.SaveAsync();
                _response.Result = villaModel;
                _response.StatusCode = HttpStatusCode.OK;

                return CreatedAtRoute("GetVilla", new { id }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
                return _response;
            }
        }

        [HttpPatch("{id:int}", Name = "UpdatePartitalVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> PatchUpdate(int id, JsonPatchDocument<VillaUpdateDTO> patchVilla)
        {
            try
            {
                if (patchVilla == null || id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var villa = await _dbVilla.GetAsync(u => u.Id == id, false);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                VillaUpdateDTO villaUpdateModel = _mapper.Map<VillaUpdateDTO>(villa);

                patchVilla.ApplyTo(villaUpdateModel, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                villa villaModel = _mapper.Map<villa>(villaUpdateModel);

                await _dbVilla.UpdateAsync(villaModel);
                await _dbVilla.SaveAsync();

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
