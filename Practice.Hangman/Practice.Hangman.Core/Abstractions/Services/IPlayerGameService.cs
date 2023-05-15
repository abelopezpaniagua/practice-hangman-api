using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Services;

public interface IPlayerGameService
{
    Task<PlayerGame?> RetrievePlayerGame(Guid id);
    Task<PlayerGame> InitializePlayerGame(Guid playerId, int gameDifficulty);
    Task<PlayerGame> ActivePlayerGame(Guid id);
    Task<PlayerGame> MakeGuessAttempt(Guid id, string guessCharacter);
}
