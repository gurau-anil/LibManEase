using FluentValidation;
using LibManEase.Application.Abstraction.DTOs;
using LibManEase.Application.Implementation.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LibManEase.Application.Implementation
{
    internal static class ValidationRegister
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            // Book
            services.AddScoped<IValidator<CreateBookDto>, CreateBookDtoValidator>();
            services.AddScoped<IValidator<UpdateBookDto>, UpdateBookDtoValidator>();

            //Member
            services.AddScoped<IValidator<CreateMemberDto>, CreateMemberDtoValidator>();
            services.AddScoped<IValidator<UpdateMemberDto>, UpdateMemberDtoValidator>();

            //Loan
            services.AddScoped<IValidator<CreateLoanDto>, CreateLoanDtoValidator>();
            services.AddScoped<IValidator<UpdateLoanDto>, UpdateLoanDtoValidator>();
        }
    }
}
