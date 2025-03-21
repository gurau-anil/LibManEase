using AutoMapper;
using LibManEase.Application.Contracts.Services;
using LibManEase.Application.DTOs;
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;

namespace LibManEase.Application.Services
{
    public class LoanService : GenericService<Loan, LoanDto, CreateLoanDto, UpdateLoanDto>, ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;

        public LoanService(ILoanRepository loanRepository, IBookRepository bookRepository, IMemberRepository memberRepository, IMapper mapper)
            : base(loanRepository, mapper)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }

        public async Task<LoanDto> CreateLoanAsync(int bookId, int memberId, DateTime dueDate)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null || !book.IsAvailable)
                throw new InvalidOperationException("Book is not available for loan.");

            var member = await _memberRepository.GetByIdAsync(memberId);
            if (member == null)
                throw new InvalidOperationException("Member not found.");

            var loan = new Loan
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.UtcNow,
                DueDate = dueDate
            };

            var createdLoan = await _loanRepository.AddAsync(loan);
            book.IsAvailable = false;
            await _bookRepository.UpdateAsync(book);

            return _mapper.Map<LoanDto>(createdLoan);
        }

        public async Task ReturnBookAsync(int loanId)
        {
            var loan = await _loanRepository.GetByIdAsync(loanId);
            if (loan == null)
                throw new InvalidOperationException("Loan not found.");

            loan.ReturnDate = DateTime.UtcNow;
            await _loanRepository.UpdateAsync(loan);

            var book = await _bookRepository.GetByIdAsync(loan.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
                await _bookRepository.UpdateAsync(book);
            }
        }

        public async Task<IEnumerable<LoanDto>> GetOverdueLoansAsync()
        {
            var overdueLoans = await _loanRepository.GetOverdueLoansAsync();
            return _mapper.Map<IEnumerable<LoanDto>>(overdueLoans);
        }
    }

}
