using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Services;

public class PlayerScoreService : IPlayerScoreService
{
    private readonly IPlayerScoreRepository _repository;

    public PlayerScoreService(IPlayerScoreRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<PlayerScore>> GetPlayerScores(int difficulty, int page = 1, int size = 20)
    {
        return await _repository.GetScoresAsync(difficulty, page, size);
    }

    public async Task<PlayerScore> SavePlayerScore(PlayerScore playerScore)
    {
        var existingEqualScore = await _repository.GetNextEqualPlayerScore(playerScore.Difficulty, playerScore.Score, playerScore.NumAttempts, playerScore.MinTimeWordGuessed);
        
        if (existingEqualScore is null)
        {
            var existingMajorScore = await _repository.GetNextMajorPlayerScore(playerScore.Difficulty, playerScore.Score);
            playerScore.Rank = existingMajorScore is null ? 1 : existingMajorScore.Rank + 1;
        }
        else
        {
            playerScore.Rank = existingEqualScore.Rank + 1;
        }

        await _repository.UpdateScoreRanking(playerScore.Difficulty, playerScore.Rank);

        var savedPlayerScore = await _repository.CreateAsync(playerScore);

        return savedPlayerScore;
    }
}
