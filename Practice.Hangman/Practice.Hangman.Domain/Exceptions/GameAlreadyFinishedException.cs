using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class GameAlreadyFinishedException : AbstractException
{
    public GameAlreadyFinishedException() : base("The game is already finished.", ExceptionSeverity.Error)
    {
    }
}
