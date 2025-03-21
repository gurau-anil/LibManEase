using LibManEase.Application.DTOs;

namespace LibManEase.Application.Contracts.Services
{
    public interface ILoanService : IGenericService<LoanDto, CreateLoanDto, UpdateLoanDto>
    {
        Task<LoanDto> CreateLoanAsync(int bookId, int memberId, DateTime dueDate);
        Task ReturnBookAsync(int loanId);
        Task<IEnumerable<LoanDto>> GetOverdueLoansAsync();
    }



}
