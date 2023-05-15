using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class AlreadyTriedCharacterException : AbstractException
{
    public AlreadyTriedCharacterException() : base("You already tried with that character.", ExceptionSeverity.Error)
    {
    }
}
