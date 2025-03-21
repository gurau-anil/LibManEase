using FluentValidation;
using LibManEase.Application.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace LibManEase.Application
{
    public static class ValidationRegister
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
