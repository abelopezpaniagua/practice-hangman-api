using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Repositories;

public interface IPlayerScoreRepository : IRepository<PlayerScore, int>
{
    Task<ICollection<PlayerScore>> GetScoresAsync(int difficulty, int page, int size);
    Task<PlayerScore?> GetNextMajorPlayerScore(int difficulty, long score);
    Task<PlayerScore?> GetNextEqualPlayerScore(int difficulty, long score, int numAttempts, long timeGuess);
    Task<bool> UpdateScoreRanking(int difficulty, int rank);
}
