using villaAPI.Data;
using villaAPI.Model;
using villaAPI.Repository.IRepository;

namespace villaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDateTime = DateTime.Now;
            _db.VillaNumber.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
