namespace Practice.Hangman.Domain.Entities;

public interface IIdentifiable<TIdentifier> where TIdentifier : struct
{
    public TIdentifier Id { get; set; }
}
