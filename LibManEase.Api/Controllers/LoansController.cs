using LibManEase.Application.Abstraction.Contracts.Services;
using LibManEase.Application.Abstraction.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibManEase.Api.Controllers
{
    public class LoansController : ApiControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService):base()
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetAllLoans()
        {
            var loans = await _loanService.GetAllAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetLoan(int id)
        {
            var loan = await _loanService.GetByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDto>> CreateLoan(CreateLoanDto createLoanDto)
        {
            var createdLoan = await _loanService.CreateLoanAsync(createLoanDto.BookId, createLoanDto.MemberId, createLoanDto.DueDate);
            return CreatedAtAction(nameof(GetLoan), new { id = createdLoan.Id }, createdLoan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan(int id, UpdateLoanDto updateLoanDto)
        {
            if (id != updateLoanDto.Id)
            {
                return BadRequest();
            }

            await _loanService.UpdateAsync(updateLoanDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            await _loanService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            await _loanService.ReturnBookAsync(id);
            return NoContent();
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetOverdueLoans()
        {
            var overdueLoans = await _loanService.GetOverdueLoansAsync();
            return Ok(overdueLoans);
        }
    }
}
