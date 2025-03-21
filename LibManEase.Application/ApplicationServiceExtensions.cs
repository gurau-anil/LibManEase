using LibManEase.Application.Contracts.Services;
using LibManEase.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibManEase.Application
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
