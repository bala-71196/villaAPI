using System.Linq.Expressions;

namespace villaAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        public Task<T> GetAsync(Expression<Func<T, bool>> filter = null,Boolean tracked = true);
        public Task CreateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task SaveAsync();
    }
}   
