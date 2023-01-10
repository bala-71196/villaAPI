using Villa_Utilities;
using VillaWebApp.Model;
using VillaWebApp.Model.DTO;
using VillaWebApp.Models;
using VillaWebApp.Services.IServices;

namespace VillaWebApp.Services
{
    public class AuthService : BaseService,IAuthService
    {
        private IHttpClientFactory _clientFactory;
        private string villaUrl;
        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Url = villaUrl + "/api/v1/UsersAuth/login",
                Data = obj
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Url = villaUrl + "/api/v1/UsersAuth/register",
                Data = obj
            });
        }
    }
}
