using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Domain.Entities;
using Practice.Hangman.Infrastructure.Data;

namespace Practice.Hangman.Infrastructure.Repositories;

public class PlayerRepository : EfRepository<Player, Guid>, IPlayerRepository
{
    public PlayerRepository(GameDbContext dbContext) : base(dbContext)
    {
    }
}
