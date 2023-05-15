namespace Practice.Hangman.Domain.Entities;

public abstract class BaseEntity<TIdentifier> : IIdentifiable<TIdentifier> where TIdentifier : struct
{
    public TIdentifier Id { get; set; }
}
