using Microsoft.AspNetCore.Mvc;
using System.Net;
using villaAPI.Model;
using villaAPI.Model.DTO;
using villaAPI.Repository.IRepository;

namespace villaAPI.Controllers
{
    [ApiController]
    [Route("/api/v{version:apiVersion}/UsersAuth")]
    [ApiVersionNeutral]
    public class UsersController : Controller
    {
        private IUserRepository _userRepo;
        private APIResponse _response;
        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new();
        }

        [HttpPost("login")]
        public async Task<ActionResult<APIResponse>> Login([FromBody] LoginRequestDTO model)
        {
            var response = await _userRepo.Login(model);

            if (response.User == null || string.IsNullOrEmpty(response.Token))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("UserName or Password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = response;

            return Ok(_response);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            bool isUnique = _userRepo.IsUniqueUser(model.UserName);

            if (!isUnique)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("UserName already exists");
                return BadRequest(_response);
            }

            var user = await _userRepo.Register(model);

            if (user == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }
    }
}
