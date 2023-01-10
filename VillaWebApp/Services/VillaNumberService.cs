using Newtonsoft.Json.Linq;
using Villa_Utilities;
using VillaWebApp.Model.DTO;
using VillaWebApp.Models;
using VillaWebApp.Services.IServices;

namespace VillaWebApp.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaNumberCreateDTO villaCreateDto, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Url = villaUrl + "/api/v1/VillaNumber",
                Data = villaCreateDto,
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaUrl + "/api/v1/VillaNumber?id=" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/v1/VillaNumber",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/v1/VillaNumber/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO villaUpdateDTO, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Url = villaUrl + "/api/v1/VillaNumber/" + villaUpdateDTO.VillaID,
                Data = villaUpdateDTO,
                Token = token
            });
        }
    }
}
