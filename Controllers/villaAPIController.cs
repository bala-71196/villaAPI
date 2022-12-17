using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using villaAPI.Data;
using villaAPI.Model;
using villaAPI.Model.DTO;

namespace villaAPI.Controllers
{
    [ApiController]
    [Route("api/villaAPI")]
    public class villaAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public villaAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<villaDTO>>> GetVillas()
        {
            IEnumerable<villa> villaModel = await _db.villas.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<villaDTO>>(villaModel));
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<villaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return NoContent();
            }

            villaDTO villaDTOObj = _mapper.Map<villaDTO>(villa);

            //villaDTO villaDTO = new ()
            //{
            //    Id = villa.Id,
            //    Name = villa.Name,
            //    Details = villa.Details,
            //    Rate = villa.Rate,
            //    Sqft = villa.Sqft,
            //    Occupancy = villa.Occupancy,
            //    ImageUrl = villa.ImageUrl,
            //    Amenity = villa.Amenity
            //};

            return villaDTOObj;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaCreateDTO>> PostVilla([FromBody] VillaCreateDTO postData)
        {
            if (postData == null)
            {
                return BadRequest();
            }
            if (await _db.villas.FirstOrDefaultAsync(u => u.Name.ToLower() == postData.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Error", "villa already present");
                return BadRequest(ModelState);
            }

            villa villaModel = _mapper.Map<villa>(postData);


            //villa villaModel = new()
            //{
            //    Id = postData.Id,
            //    Name = postData.Name,
            //    Amenity = postData.Amenity,
            //    Rate = postData.Rate,
            //    Sqft = postData.Sqft,
            //    Details = postData.Details,
            //    ImageUrl = postData.ImageUrl,
            //    Occupancy = postData.Occupancy,
            //    CreatedDate = DateTime.Now
            //};


            await _db.villas.AddAsync(villaModel);
            await _db.SaveChangesAsync();
            
            return CreatedAtRoute("GetVilla", new { id = villaModel.Id }, villaModel);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var villa = await _db.villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            _db.villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<VillaUpdateDTO>> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateVilla)
        {
            if (id == 0 || updateVilla == null || id != updateVilla.Id)
            {
                return BadRequest();
            }

            villa villaModel = _mapper.Map<villa>(updateVilla);

            //var villa = _db.villas.FirstOrDefault(u => u.Id == id);

            //if (villa == null)
            //{
            //    return BadRequest("villa is not available");
            //}
            //villa villaModel = new villa()
            //{
            //    Id = updateVilla.Id,
            //    Name = updateVilla.Name,
            //    Details = updateVilla.Details,
            //    Rate = updateVilla.Rate,
            //    Sqft = updateVilla.Sqft,
            //    Occupancy = updateVilla.Occupancy,
            //    ImageUrl = updateVilla.ImageUrl,
            //    Amenity = updateVilla.Amenity
            //};

            _db.villas.Update(villaModel);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id }, villaModel);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartitalVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PatchUpdate(int id, JsonPatchDocument<VillaUpdateDTO> patchVilla)
        {
            if (patchVilla == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return BadRequest();
            }

            VillaUpdateDTO villaUpdateModel = _mapper.Map<VillaUpdateDTO>(villa);

            //villaDTO villaDTO = new()
            //{
            //    Id = villa.Id,
            //    Name = villa.Name,
            //    Details = villa.Details,
            //    Rate = villa.Rate,
            //    Sqft = villa.Sqft,
            //    Occupancy = villa.Occupancy,
            //    ImageUrl = villa.ImageUrl,
            //    Amenity = villa.Amenity
            //};

            patchVilla.ApplyTo(villaUpdateModel, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            villa villaModel = _mapper.Map<villa>(villaUpdateModel);

            //villa villamodel = new()
            //{
            //    Id = villaDTO.Id,
            //    Name = villaDTO.Name,
            //    Details = villaDTO.Details,
            //    Rate = villaDTO.Rate,
            //    Sqft = villaDTO.Sqft,
            //    Occupancy = villaDTO.Occupancy,
            //    ImageUrl = villaDTO.ImageUrl,
            //    Amenity = villaDTO.Amenity,
            //};

            _db.Update(villaModel);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
