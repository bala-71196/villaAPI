using villaAPI.Model;

namespace villaAPI.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        public Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
