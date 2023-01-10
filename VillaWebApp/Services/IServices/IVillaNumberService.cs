using VillaWebApp.Model.DTO;

namespace VillaWebApp.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaNumberCreateDTO villaCreateDto, string token);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDTO villaUpdateDTO, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
