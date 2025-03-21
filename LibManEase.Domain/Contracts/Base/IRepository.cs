using LibManEase.Domain.Entities.Base;

namespace LibManEase.Domain.Contracts.Base
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
