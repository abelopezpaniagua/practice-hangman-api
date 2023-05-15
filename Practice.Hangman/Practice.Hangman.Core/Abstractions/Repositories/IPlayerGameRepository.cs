using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Repositories;

public interface IPlayerGameRepository : IRepository<PlayerGame, Guid>
{
}
