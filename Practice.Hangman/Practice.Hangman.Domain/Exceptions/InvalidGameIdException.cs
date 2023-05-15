using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class InvalidGameIdException : AbstractException
{
    public InvalidGameIdException() : base("Invalid game ID.", ExceptionSeverity.Error)
    {
    }
}
