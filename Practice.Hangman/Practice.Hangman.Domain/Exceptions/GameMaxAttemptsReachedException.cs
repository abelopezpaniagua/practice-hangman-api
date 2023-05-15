using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class GameMaxAttemptsReachedException : AbstractException
{
    public GameMaxAttemptsReachedException() : base("You already reached the maximium allowed attemps.", ExceptionSeverity.Error)
    {
    }
}
