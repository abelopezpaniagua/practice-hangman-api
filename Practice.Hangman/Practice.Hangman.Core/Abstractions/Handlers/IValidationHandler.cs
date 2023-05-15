namespace Practice.Hangman.Core.Abstractions.Handlers;

public interface IValidationHandler<T> where T : class
{
    void Handle(T request);
}
