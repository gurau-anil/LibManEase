﻿using LibManEase.Application.Abstraction.Contracts.Services;
using LibManEase.Application.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibManEase.Application.Implementation
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,,>));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IMemberService, MemberService>();

            //Register Validators
            services.RegisterValidators();
            
            //services.AddValidatorsFromAssemblyContaining<CreateBookDtoValidator>(); -- register all the Validators all at once.

            return services;
        }
    }
}
