using NinoBank.Application;
using NinoBank.Infrastructure;

namespace NinoBank.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        builder.Services
                .AddWebApi(configuration)
                .AddApplication(configuration)
                .Addinfrastructure(configuration)
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConsole(); 
                });

     
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
