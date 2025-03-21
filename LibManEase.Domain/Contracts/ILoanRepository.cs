using LibManEase.Domain.Contracts.Base;
using LibManEase.Domain.Entities;

namespace LibManEase.Domain.Contracts
{
    // Domain/Contracts/ILoanRepository.cs
    public interface ILoanRepository : IRepository<Loan, int>
    {
        Task<IEnumerable<Loan>> GetOverdueLoansAsync();
    }

}
