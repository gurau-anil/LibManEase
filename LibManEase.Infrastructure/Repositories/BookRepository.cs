
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;
using LibManEase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibManEase.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return await _dbContext.Books.Where(b => b.IsAvailable).ToListAsync();
        }
    }

}

