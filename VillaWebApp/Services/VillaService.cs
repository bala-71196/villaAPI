using Villa_Utilities;
using VillaWebApp.Model.DTO;
using VillaWebApp.Models;
using VillaWebApp.Services.IServices;

namespace VillaWebApp.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaCreateDTO villaCreateDto, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Url = villaUrl + "/api/v1/villaAPI",
                Data = villaCreateDto,
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaUrl + "/api/v1/villaAPI?id=" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/v1/villaAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/villaAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO villaUpdateDTO, string token)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Url = villaUrl + "/api/villaAPI/"+villaUpdateDTO.Id,
                Data = villaUpdateDTO,
                Token = token
            });
        }
    }
}
