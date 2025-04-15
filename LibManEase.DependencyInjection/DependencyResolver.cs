using LibManEase.Application.Implementation;
using LibManEase.Application.Implementation.Features.Books.Queries;
using LibManEase.Infrastructure;
using LibManEase.Infrastructure.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibManEase.DependencyResolver
{
    public static class DependencyResolver
    {
        public static void ResolveApplicationDependency(this IServiceCollection services)
        {
            //Add Application Services
            services.AddApplicationServices();
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(typeof(GetBookByIdHandler).Assembly));
        }

        public static void ResolveInfrastructureDependency(this IServiceCollection services, IConfiguration configuration, Action<SerilogConfiguration> logConfig = null)
        {
            //Add Infrastructure Services
            services.AddInfrastructureServices(configuration.GetConnectionString("DefaultConnection") ?? String.Empty, logConfig);
        }
    }
}
