using Microsoft.EntityFrameworkCore;
using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Domain.Entities;
using Practice.Hangman.Infrastructure.Data;

namespace Practice.Hangman.Infrastructure.Repositories;

public class PlayerGameRepository : EfRepository<PlayerGame, Guid>, IPlayerGameRepository
{
    public PlayerGameRepository(GameDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<PlayerGame?> GetById(Guid id)
    {
        var playerGame = await _dbContext.Set<PlayerGame>()
            .AsNoTracking()
            .Include(pg => pg.Player)
            .Include(pg => pg.GuessWord)
            .FirstOrDefaultAsync(pg => pg.Id.Equals(id));

        return playerGame;
    }
}
