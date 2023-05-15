using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public class InvalidGuessCharacterException : AbstractException
{
    public InvalidGuessCharacterException() : base("Invalid guess character.", ExceptionSeverity.Error)
    {
    }
}
