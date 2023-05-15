using Microsoft.EntityFrameworkCore;
using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Domain.Entities;
using Practice.Hangman.Infrastructure.Data;

namespace Practice.Hangman.Infrastructure.Repositories;

public class GuessWordRepository : EfRepository<GuessWord, int>, IGuessWordRepository
{
    public GuessWordRepository(GameDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<GuessWord?> RetrieveRandomGuessWordByDifficulty(int dificulty)
    {
        return await _dbContext.Set<GuessWord>()
            .OrderBy(x => Guid.NewGuid())
            .FirstOrDefaultAsync(x => x.Difficulty.Equals(dificulty));
    }
}
