using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Exceptions;

public abstract class AbstractException : Exception
{
    public string FriendlyMessage { get; protected set; }
    public ExceptionSeverity Severity { get; protected set; }

    protected AbstractException(string friendlyMessage, ExceptionSeverity severity = ExceptionSeverity.Error)
    {
        FriendlyMessage = friendlyMessage;
        Severity = severity;
    }
}
