using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NinoBank.Application.Models.Configurations;
using NinoBank.Application.Services;
using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using System.Reflection;

namespace NinoBank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<TokenService>();

            services.AddScoped<UserManager<User>>();

            services.AddScoped<DbContext, DataContext>();

            services.AddIdentity<User, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<DataContext>();

            return services;
        }
    }
}
