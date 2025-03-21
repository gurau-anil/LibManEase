using FluentValidation;

namespace LibManEase.Application.DTOs
{
    public class BookDto : BaseDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CreateBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
    }

    public class UpdateBookDto : BaseDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }

    #region validators
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ISBN).NotEmpty().Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")
                .WithMessage("ISBN must be a valid 10 or 13-digit number");
            RuleFor(x => x.PublicationYear).InclusiveBetween(1000, DateTime.Now.Year);
        }
    }

    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
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
    #endregion
}
