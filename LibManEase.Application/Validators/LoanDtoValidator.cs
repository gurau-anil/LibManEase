using FluentValidation;
using LibManEase.Application.Abstraction.DTOs;

namespace LibManEase.Application.Implementation.Validators
{
    internal class CreateLoanDtoValidator : AbstractValidator<CreateLoanDto>
    {
        public CreateLoanDtoValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0);
            RuleFor(x => x.MemberId).GreaterThan(0);
            RuleFor(x => x.DueDate).GreaterThan(DateTime.Now);
        }
    }

    internal class UpdateLoanDtoValidator : AbstractValidator<UpdateLoanDto>
    {
        public UpdateLoanDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.ReturnDate).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
