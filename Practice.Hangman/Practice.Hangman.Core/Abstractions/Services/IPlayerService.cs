using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Services;

public interface IPlayerService
{
    Task<Player> CreatePlayer(Player player);
    Task<Player?> RetrievePlayer(Guid playerId);
    Task<Player> UpdatePlayer(Player player);
}
