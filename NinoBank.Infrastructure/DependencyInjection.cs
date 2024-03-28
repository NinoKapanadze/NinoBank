using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NinoBank.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection Addinfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
