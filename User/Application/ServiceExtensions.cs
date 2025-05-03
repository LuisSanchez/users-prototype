using Microsoft.Extensions.DependencyInjection;
using User.Application.Interfaces;
using User.Infrastructure.Services;

namespace User.Application
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IAuthService, KeycloakAuthService>();
        }
    }
}
