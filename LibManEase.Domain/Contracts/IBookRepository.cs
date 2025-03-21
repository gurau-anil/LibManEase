using LibManEase.Domain.Contracts.Base;
using LibManEase.Domain.Entities;

namespace LibManEase.Domain.Contracts
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<IEnumerable<Book>> GetAvailableBooksAsync();
    }

}
