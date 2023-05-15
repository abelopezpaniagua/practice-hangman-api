using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class PlayerNotFoundException : AbstractException
{
    public PlayerNotFoundException() : base("Player not found", ExceptionSeverity.Error)
    {
    }
}
