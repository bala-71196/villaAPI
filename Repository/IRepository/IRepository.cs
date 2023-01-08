using System.Linq.Expressions;

namespace villaAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,int pageSize = 0,int pageNumber = 1);
        public Task<T> GetAsync(Expression<Func<T, bool>> filter = null,bool tracked = true, string? includeProperties = null);
        public Task CreateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task SaveAsync();
    }
}   
