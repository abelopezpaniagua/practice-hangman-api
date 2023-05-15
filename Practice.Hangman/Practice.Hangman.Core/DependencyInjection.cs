using Microsoft.Extensions.DependencyInjection;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Core.Services;

namespace Practice.Hangman.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IPlayerService, PlayerService>()
            .AddScoped<IPlayerGameService, PlayerGameService>()
            .AddScoped<IPlayerScoreService, PlayerScoreService>()
            .AddScoped<IGuessWordService, GuessWordService>();
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services.AddAutoMapper(typeof(DependencyInjection));
    }
}