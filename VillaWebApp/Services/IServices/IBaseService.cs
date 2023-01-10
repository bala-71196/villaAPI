using VillaWebApp.Model;
using VillaWebApp.Models;

namespace VillaWebApp.Services.IServices
{
    public interface IBaseService
    {
        Task<T> sendAsync<T>(APIRequest apiRequest);
        APIResponse responseModel { get; set;}
    }
}
