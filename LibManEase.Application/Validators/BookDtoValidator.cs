using FluentValidation;
using LibManEase.Application.Abstraction.DTOs;

namespace LibManEase.Application.Implementation.Validators
{
    internal class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ISBN).NotEmpty().Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")
                .WithMessage("ISBN must be a valid 10 or 13-digit number");
            RuleFor(x => x.PublicationYear).InclusiveBetween(1000, DateTime.Now.Year);
        }
    }

    internal class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ISBN).NotEmpty().Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")
                .WithMessage("ISBN must be a valid 10 or 13-digit number");
            RuleFor(x => x.PublicationYear).InclusiveBetween(1000, DateTime.Now.Year);
        }
    }
}
