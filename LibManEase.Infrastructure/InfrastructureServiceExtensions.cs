using LibManEase.Application.Abstraction.Contracts.Logging;
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Contracts.Base;
using LibManEase.Domain.Entities;
using LibManEase.Infrastructure.Data;
using LibManEase.Infrastructure.Logger;
using LibManEase.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LibManEase.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString, Action<SerilogConfiguration> logConfig = null)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, opt => {
                    opt.CommandTimeout(30);
                });

                options.UseSeeding((context, _) =>
                {
                    var book = context.Set<Book>().FirstOrDefault();
                    if (book == null)
                    {
                        context.Set<Book>().AddRange(new List<Book>
                        {
                            new Book { Title = "Book 1", ISBN = "1234567890", IsAvailable = true },
                            new Book { Title = "Book 2", ISBN = "0987654321", IsAvailable = true },
                        });
                        context.SaveChanges();
                    }
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    var book = context.Set<Book>().FirstOrDefaultAsync();
                    if (book == null)
                    {
                        context.Set<Book>().AddRange(new List<Book>
                        {
                            new Book { Title = "Book 1", ISBN = "1234567890", IsAvailable = true },
                            new Book { Title = "Book 2", ISBN = "0987654321", IsAvailable = true },
                        });
                        await context.SaveChangesAsync();
                    }
                });
            });

            //services.AddScoped(typeof(IRepository<,>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            SerilogConfiguration configuration = new SerilogConfiguration();
            logConfig?.Invoke(configuration);

            services.AddSingleton<IAppLogger>(sp => new SerilogLogger(ConfigureLogger(configuration)));

            return services;
        }

        private static Serilog.ILogger ConfigureLogger(SerilogConfiguration configuration)
        {
            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.Debug() // Set minimum logging level
                .WriteTo.Console();

            if (!String.IsNullOrEmpty(configuration.LogFilePath))
            {
                loggerConfig.WriteTo.File(configuration.LogFilePath, rollingInterval: configuration.RollingInterval, retainedFileCountLimit: configuration.RetainedFileCountLimit);
            }
            return loggerConfig.CreateLogger();

        }
    }
}
