using Practice.Hangman.Core.Abstractions.Handlers;
using Practice.Hangman.Core.Models;
using Practice.Hangman.Domain.Enums;
using Practice.Hangman.Domain.Exceptions;

namespace Practice.Hangman.Core.Handlers.Validation;

public class GameActiveValidationHandler : IValidationHandler<GuessWordAttemptRequest>
{
    public void Handle(GuessWordAttemptRequest request)
    {
        if (request.PlayerGame.Status != GameStatus.Active)
        {
            throw new GameAlreadyFinishedException();
        }
    }
}
