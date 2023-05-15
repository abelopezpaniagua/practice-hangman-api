using Practice.Hangman.Core.Abstractions.Handlers;
using Practice.Hangman.Core.Models;
using Practice.Hangman.Domain.Exceptions;

namespace Practice.Hangman.Core.Handlers.Validation;

public class GuessCharacterValidationHandler : IValidationHandler<GuessWordAttemptRequest>
{
    public void Handle(GuessWordAttemptRequest request)
    {
        if (string.IsNullOrEmpty(request.GuessCharacter.Trim()))
        {
            throw new InvalidGuessCharacterException();
        }

        var guessCharToVerify = request.GuessCharacter.First();

        if (!char.IsLetter(guessCharToVerify))
        {
            throw new InvalidGuessCharacterException();
        }

        if (request.PlayerGame.AttemptedChars.Contains(guessCharToVerify))
        {
            throw new AlreadyTriedCharacterException();
        }
    }
}
