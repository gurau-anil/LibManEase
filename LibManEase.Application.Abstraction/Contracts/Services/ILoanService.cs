using LibManEase.Application.Abstraction.DTOs;

namespace LibManEase.Application.Abstraction.Contracts.Services
{
    public interface ILoanService : IGenericService<LoanDto, CreateLoanDto, UpdateLoanDto>
    {
        Task<LoanDto> CreateLoanAsync(int bookId, int memberId, DateTime dueDate);
        Task ReturnBookAsync(int loanId);
        Task<IEnumerable<LoanDto>> GetOverdueLoansAsync();
    }
}
