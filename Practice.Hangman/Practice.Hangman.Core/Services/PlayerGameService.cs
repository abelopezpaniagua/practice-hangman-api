using Practice.Hangman.Core.Abstractions.Handlers;
using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Core.Handlers.Validation;
using Practice.Hangman.Core.Models;
using Practice.Hangman.Domain.Entities;
using Practice.Hangman.Domain.Enums;
using Practice.Hangman.Domain.Exceptions;

namespace Practice.Hangman.Core.Services;

public class PlayerGameService : IPlayerGameService
{
    private readonly IPlayerGameRepository _repository;
    private readonly IPlayerService _playerService;
    private readonly IGuessWordService _guessWordService;
    private readonly IPlayerScoreService _scoreService;

    private readonly ICollection<IValidationHandler<GuessWordAttemptRequest>> _validationHandlers = new List<IValidationHandler<GuessWordAttemptRequest>>();

    public PlayerGameService(IPlayerGameRepository repository, IPlayerService playerService, IGuessWordService guessWordService, IPlayerScoreService scoreService)
    {
        _repository = repository;
        _playerService = playerService;
        _guessWordService = guessWordService;
        _scoreService = scoreService;

        _validationHandlers.Add(new GameActiveValidationHandler());
        _validationHandlers.Add(new GameAttemptsValidationHandler());
        _validationHandlers.Add(new GuessCharacterValidationHandler());
    }

    public async Task<PlayerGame> InitializePlayerGame(Guid playerId, int gameDifficulty = 1)
    {
        var player = await _playerService.RetrievePlayer(playerId);

        if (player == null)
        {
            throw new PlayerNotFoundException();
        }

        var randomGuessWord = await _guessWordService.GetRandomGuessWord(gameDifficulty);

        var playerGame = new PlayerGame
        {
            PlayerId = player.Id,
            GuessWordId = randomGuessWord.Id,
            CurrentScore = 0,
            TotalAttempts = 0,
            SuccessfulAttempts = 0,
            Status = GameStatus.Inactive
        };

        var initPlayerGame = await _repository.CreateAsync(playerGame);

        return initPlayerGame;
    }

    public async Task<PlayerGame> ActivePlayerGame(Guid id)
    {
        var playerGame = await RetrievePlayerGame(id);

        if (playerGame is null)
        {
            throw new InvalidGameIdException();
        }

        if (playerGame.Status != GameStatus.Inactive)
        {
            throw new GameAlreadyActiveException();
        }

        playerGame.Status = GameStatus.Active;
        playerGame.StartAt = DateTimeOffset.UtcNow;

        return await _repository.UpdateAsync(playerGame);
    }

    public async Task<PlayerGame> MakeGuessAttempt(Guid id, string guessCharacter)
    {
        var playerGame = await RetrievePlayerGame(id);
        
        if (playerGame is null)
        {
            throw new InvalidGameIdException();
        }

        var request = new GuessWordAttemptRequest
        {
            PlayerGame = playerGame,
            GuessCharacter = guessCharacter
        };

        foreach (var handler in _validationHandlers)
        {
            handler.Handle(request);
        }

        var guessCharToVerify = guessCharacter.First();
        
        playerGame.AttemptedChars.Add(guessCharToVerify);
        playerGame.TotalAttempts++;

        var isCorrectAttempt = _guessWordService.VerifyCorrectGuessChar(playerGame.GuessWord, guessCharToVerify);

        if (isCorrectAttempt)
        {
            playerGame.GuessedChars.Add(guessCharToVerify);
            playerGame.SuccessfulAttempts++;
            playerGame.CurrentScore += playerGame.AttemptScore;
        }

        if (playerGame.WordIsGuessed || playerGame.RemainingAttempts <= 0)
        {
            playerGame.FinishedAt = DateTimeOffset.UtcNow;
            playerGame.Status = playerGame.WordIsGuessed ? GameStatus.Completed : GameStatus.GameOver;

            if (playerGame.WordIsGuessed)
            {
                if (!playerGame.GuessedWordTimeElapsed.HasValue)
                {
                    throw new GameTimesNotDefinedException();
                }

                var playerScore = new PlayerScore
                {
                    PlayerId = playerGame.PlayerId,
                    Difficulty = playerGame.GuessWord.Difficulty,
                    Score = playerGame.CurrentScore,
                    NumAttempts = playerGame.TotalAttempts,
                    MinTimeWordGuessed = playerGame.GuessedWordTimeElapsed.Value
                };
                var savedPlayerScore = await _scoreService.SavePlayerScore(playerScore);
                playerGame.Player.Rank = savedPlayerScore.Rank;
                await _playerService.UpdatePlayer(playerGame.Player);
            }
        }

        return await _repository.UpdateAsync(playerGame);
    }

    public Task<PlayerGame?> RetrievePlayerGame(Guid id)
    {
        var playerGame = _repository.GetById(id); 
        
        return playerGame;
    }
}
