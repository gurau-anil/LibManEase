
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;
using LibManEase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibManEase.Infrastructure.Repositories
{
    public class LoanRepository : Repository<Loan, int>, ILoanRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Loan>> GetOverdueLoansAsync()
        {
            return await _dbContext.Loans.Where(l => l.DueDate < DateTime.UtcNow && l.ReturnDate == null).ToListAsync();
        }
    }

}

