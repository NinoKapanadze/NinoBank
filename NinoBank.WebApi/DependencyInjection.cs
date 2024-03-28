using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using System.Reflection;

namespace NinoBank.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nino Bank API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

            services.AddScoped<DbContext, DataContext>();

            services.AddScoped<UserManager<User>>();

            services.AddIdentity<User, IdentityRole<Guid>>() 
                    .AddEntityFrameworkStores<DataContext>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
