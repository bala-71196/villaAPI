﻿using VillaWebApp.Model.DTO;

namespace VillaWebApp.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaCreateDTO villaCreateDto, string token);
        Task<T> UpdateAsync<T>(VillaUpdateDTO villaUpdateDTO, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
