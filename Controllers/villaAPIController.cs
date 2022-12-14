using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger _logger;
        public villaAPIController(ILogger<villaAPIController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<villaDTO>> GetVillas() => Ok(villaData.villaIM);

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<villaDTO> GetVilla(int id)
        {
            _logger.LogInformation("inside get verb");
            if(id == 0)
            {
                _logger.LogError("bad request");
                return BadRequest();
            }

            var villa = villaData.villaIM.FirstOrDefault(u => u.Id == id);

            if(villa == null)
            {
                return NoContent();
            }
            return villa;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<villaDTO> PostVilla([FromBody] villaDTO postData)
        {
            

            if(postData == null)
            {
                return BadRequest();
            }
            if (villaData.villaIM.FirstOrDefault(u => u.Name.ToLower() == postData.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Error", "villa already present");
                return BadRequest(ModelState);
            }
            postData.Id = villaData.villaIM.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            villaData.villaIM.Add(postData);
            return CreatedAtRoute("GetVilla",new { id = postData.Id }, postData);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            var villa = villaData.villaIM.FirstOrDefault(u => u.Id == id);

            if(villa == null)
            {
                return NotFound();
            }

            villaData.villaIM.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<villaDTO> UpdateVilla(int id, [FromBody] villaDTO updateVilla)
        {
            if (id == 0 || updateVilla == null)
            {
                return BadRequest();
            }

            var villa = villaData.villaIM.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return BadRequest("villa is not available");
            }
            villa.Name = updateVilla.Name;

            return CreatedAtRoute("GetVilla",new { id },villa);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartitalVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult PatchUpdate(int id, JsonPatchDocument<villaDTO> patchVilla)
        {
            if(patchVilla == null || id == 0)
            {
                return BadRequest();
            }
            var villa = villaData.villaIM.FirstOrDefault(u => u.Id == id);
            
            if (villa == null)
            {
                return BadRequest();
            }
            patchVilla.ApplyTo(villa,ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
