using System.Linq.Expressions;

namespace JetHealth.Data.Repository.IRepository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task DeleteAsync(T entity);
        Task AddAsync(T entity);
    }
}
