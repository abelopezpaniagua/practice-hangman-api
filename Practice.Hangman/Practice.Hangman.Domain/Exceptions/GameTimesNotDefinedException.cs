using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class GameTimesNotDefinedException : AbstractException
{
    public GameTimesNotDefinedException() : base("Error start or finished times are not defined.", ExceptionSeverity.Error)
    {
    }
}
