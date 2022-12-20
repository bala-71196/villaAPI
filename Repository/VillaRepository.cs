using villaAPI.Data;
using villaAPI.Model;
using villaAPI.Repository.IRepository;

namespace villaAPI.Repository
{
    public class VillaRepository : Repository<villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<villa> UpdateAsync(villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
