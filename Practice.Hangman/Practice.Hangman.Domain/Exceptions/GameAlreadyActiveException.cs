using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class GameAlreadyActiveException : AbstractException
{
    public GameAlreadyActiveException() : base("This game cannot be activated again.", ExceptionSeverity.Error)
    {
    }
}
