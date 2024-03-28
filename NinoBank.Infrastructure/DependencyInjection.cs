using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;
using NinoBank.Infrastructure.Repositories.Base;
using NinoBank.Infrastructure.UnitOfWorks.Interfaces;
using NinoBank.Infrastructure.UnitOfWorks;
using NinoBank.Infrastructure.Repositories;

namespace NinoBank.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection Addinfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();


            services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
            services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
