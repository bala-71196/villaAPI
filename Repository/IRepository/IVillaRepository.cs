using villaAPI.Model;

namespace villaAPI.Repository.IRepository
{
    public interface IVillaRepository : IRepository<villa>
    {
        public Task<villa> UpdateAsync(villa entity);
    }
}
