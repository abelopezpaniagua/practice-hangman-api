using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Services;

public interface IPlayerScoreService
{
    Task<PlayerScore> SavePlayerScore(PlayerScore playerScore);
    Task<ICollection<PlayerScore>> GetPlayerScores(int difficulty, int page, int size);
}
