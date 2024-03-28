using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using System.Reflection;

namespace NinoBank.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

            services.AddScoped<DbContext, DataContext>();

            services.AddScoped<UserManager<User>>();


            services.AddIdentity<User, IdentityRole<Guid>>() // Replace IdentityRole<Guid> with whatever role class you're using
                    .AddEntityFrameworkStores<DataContext>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
