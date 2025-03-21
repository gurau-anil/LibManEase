using LibManEase.Application;
using LibManEase.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibManEase.DependencyResolver
{
    public static class DependencyResolver
    {
        public static void SetupServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Application Services
            services.AddApplicationServices();

            //Add Infrastructure Services
            services.AddInfrastructureServices(configuration.GetConnectionString("DefaultConnection")?? String.Empty);
        }
    }
}
