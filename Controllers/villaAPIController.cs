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
        public villaAPIController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<villaDTO>> GetVillas() => Ok(_db.villas.ToList());

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<villaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = _db.villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NoContent();
            }
            villaDTO villaDTO = new ()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity
            };

            return villaDTO;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<villaDTO> PostVilla([FromBody] villaDTO postData)
        {
            if (postData == null)
            {
                return BadRequest();
            }
            if (_db.villas.FirstOrDefault(u => u.Name.ToLower() == postData.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Error", "villa already present");
                return BadRequest(ModelState);
            }

            villa villaModel = new()
            {
                Id = postData.Id,
                Name = postData.Name,
                Amenity = postData.Amenity,
                Rate = postData.Rate,
                Sqft = postData.Sqft,
                Details = postData.Details,
                ImageUrl = postData.ImageUrl,
                Occupancy = postData.Occupancy,
                CreatedDate = DateTime.Now
            };


            _db.villas.Add(villaModel);
            _db.SaveChanges();
            
            return CreatedAtRoute("GetVilla", new { id = postData.Id }, villaModel);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            var villa = _db.villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            _db.villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<villaDTO> UpdateVilla(int id, [FromBody] villaDTO updateVilla)
        {
            if (id == 0 || updateVilla == null || id != updateVilla.Id)
            {
                return BadRequest();
            }

            //var villa = _db.villas.FirstOrDefault(u => u.Id == id);

            //if (villa == null)
            //{
            //    return BadRequest("villa is not available");
            //}
            villa villaModel = new villa()
            {
                Id = updateVilla.Id,
                Name = updateVilla.Name,
                Details = updateVilla.Details,
                Rate = updateVilla.Rate,
                Sqft = updateVilla.Sqft,
                Occupancy = updateVilla.Occupancy,
                ImageUrl = updateVilla.ImageUrl,
                Amenity = updateVilla.Amenity
            };

            _db.villas.Update(villaModel);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id }, villaModel);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartitalVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchUpdate(int id, JsonPatchDocument<villaDTO> patchVilla)
        {
            if (patchVilla == null || id == 0)
            {
                return BadRequest();
            }
            var villa = _db.villas.AsNoTracking().FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return BadRequest();
            }

            villaDTO villaDTO = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity
            };

            patchVilla.ApplyTo(villaDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            villa villamodel = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity,
            };

            _db.Update(villamodel);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
