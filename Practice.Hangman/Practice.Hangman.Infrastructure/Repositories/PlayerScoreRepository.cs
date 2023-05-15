using Microsoft.EntityFrameworkCore;
using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Domain.Entities;
using Practice.Hangman.Infrastructure.Data;

namespace Practice.Hangman.Infrastructure.Repositories;

public class PlayerScoreRepository : EfRepository<PlayerScore, int>, IPlayerScoreRepository
{
    public PlayerScoreRepository(GameDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<PlayerScore?> GetNextEqualPlayerScore(int difficulty, long score, int numAttempts, long timeGuess)
    {
        return await _dbContext.Set<PlayerScore>()
            .AsNoTracking()
            .Where(ps => ps.Difficulty.Equals(difficulty) && ps.Score.Equals(score) && ps.NumAttempts <= numAttempts && ps.MinTimeWordGuessed < timeGuess)
            .OrderByDescending(ps => ps.Rank)
            .FirstOrDefaultAsync();
    }

    public async Task<PlayerScore?> GetNextMajorPlayerScore(int difficulty, long score)
    {
        return await _dbContext.Set<PlayerScore>()
            .AsNoTracking()
            .Where(ps => ps.Difficulty.Equals(difficulty) && ps.Score > score)
            .OrderByDescending(ps => ps.Rank)
            .FirstOrDefaultAsync();
    }

    public async Task<ICollection<PlayerScore>> GetScoresAsync(int difficulty, int page, int size)
    {
        return await _dbContext.Set<PlayerScore>()
            .AsNoTracking()
            .Include(ps => ps.Player)
            .Where(ps => ps.Difficulty.Equals(difficulty))
            .Skip((page - 1) * size)
            .Take(size)
            .OrderBy(ps => ps.Rank)
            .ToListAsync();
    }

    public async Task<bool> UpdateScoreRanking(int difficulty, int rank)
    {
        var updatedScores = await _dbContext.Set<PlayerScore>()
            .Where(ps => ps.Difficulty.Equals(difficulty) && ps.Rank >= rank)
            .ExecuteUpdateAsync(p => p.SetProperty(ps => ps.Rank, ps => ps.Rank + 1));

        return updatedScores > 0;
    }
}
