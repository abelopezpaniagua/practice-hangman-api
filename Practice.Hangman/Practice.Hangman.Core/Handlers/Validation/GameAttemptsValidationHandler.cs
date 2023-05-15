using Practice.Hangman.Core.Abstractions.Handlers;
using Practice.Hangman.Core.Models;
using Practice.Hangman.Domain.Constants;
using Practice.Hangman.Domain.Exceptions;

namespace Practice.Hangman.Core.Handlers.Validation;

public class GameAttemptsValidationHandler : IValidationHandler<GuessWordAttemptRequest>
{
    public void Handle(GuessWordAttemptRequest request)
    {
        var failedAttempts = request.PlayerGame.TotalAttempts - request.PlayerGame.SuccessfulAttempts;

        if (failedAttempts >= GameConstants.MaxAttempts)
        {
            throw new GameMaxAttemptsReachedException();
        }
    }
}
