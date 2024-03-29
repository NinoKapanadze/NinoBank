using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NinoBank.Application.Models.Configurations;
using NinoBank.Infrastructure.Data;
using System.Reflection;

namespace NinoBank.WebApi
{
    public static class DependencyInjection
    {
        private static  readonly IOptions<JWTConfiguration>? _options;

        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V2", new OpenApiInfo { Title = "Nino Bank API", Version = "V2" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http, 
                    Scheme = "bearer", 
                    BearerFormat = "JWT", 
                    In = ParameterLocation.Header, 
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer"
                            }
                        },

                        Array.Empty<string>()
                    }
                });

                option.CustomSchemaIds(type => type.ToString());
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(x =>
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(_options.Value.Secret)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = _options.Value.ValidIssuer,
                        ValidAudience = _options.Value.ValidAudience
                    });

            services.Configure<JWTConfiguration>(configuration.GetSection("JWTConfiguration"));

            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
