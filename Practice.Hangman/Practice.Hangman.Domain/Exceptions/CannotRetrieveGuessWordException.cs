using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class CannotRetrieveGuessWordException : AbstractException
{
    public CannotRetrieveGuessWordException() : base("Cannot retrieve Guess Word.", ExceptionSeverity.Error)
    {
    }
}
