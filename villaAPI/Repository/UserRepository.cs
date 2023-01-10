using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using villaAPI.Data;
using villaAPI.Model;
using villaAPI.Model.DTO;
using villaAPI.Repository.IRepository;

namespace villaAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IMapper _mapper;
        private string secretKey;
        public UserRepository(RoleManager<IdentityRole> roleManager,IMapper mapper, ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());

            if (user == null)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == loginRequestDTO.UserName);

            bool isValid = await _userManager.CheckPasswordAsync(user,loginRequestDTO.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                User = _mapper.Map<UserDTO>(user),
                Token = tokenHandler.WriteToken(token),
            };

            return loginResponseDTO;

        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDTO.UserName,
                Email = registrationRequestDTO.UserName,
                NormalizedEmail = registrationRequestDTO.UserName.ToUpper(),
                Name = registrationRequestDTO.Name,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                    }
                    await _userManager.AddToRoleAsync(user, "admin");
                    var userToReturn = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName); ;
                    return _mapper.Map<UserDTO>(userToReturn) ;
                }
                
            } catch(Exception ex)
            {

            }

            return new UserDTO() { };
        }
    }
}
