using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Player> CreatePlayer(Player player)
    {
        player.AvatarUrl = $"https://api.multiavatar.com/{player.Nickname}.png";
        player.Rank = -1;
        player.RegisteredDate = DateTime.UtcNow;

        var createdPlayer = await _repository.CreateAsync(player);

        return createdPlayer;
    }

    public async Task<Player?> RetrievePlayer(Guid playerId)
    {
        var player = await _repository.GetById(playerId);

        return player;
    }

    public async Task<Player> UpdatePlayer(Player player)
    {
        return await _repository.UpdateAsync(player);
    }
}
