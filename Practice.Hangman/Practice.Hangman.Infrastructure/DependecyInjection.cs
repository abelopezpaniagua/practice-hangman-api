using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Infrastructure.Data;
using Practice.Hangman.Infrastructure.Data.DataGenerators;
using Practice.Hangman.Infrastructure.Repositories;
using Serilog;

namespace Practice.Hangman.Infrastructure;

public static class DependecyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<GameDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("GameDb"));
        })
            .AddScoped<IPlayerRepository, PlayerRepository>()
            .AddScoped<IGuessWordRepository, GuessWordRepository>()
            .AddScoped<IPlayerGameRepository, PlayerGameRepository>()
            .AddScoped<IPlayerScoreRepository, PlayerScoreRepository>();
    }

    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        return services.AddSingleton<IDataGenerator, CustomDataGenerator>();
    }

    public static IHostBuilder AddLogger(this IHostBuilder hosting)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateBootstrapLogger();

        return hosting.UseSerilog();
    }
}
