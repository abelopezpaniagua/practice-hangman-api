using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Services;

public interface IDataGenerator
{
    ICollection<GuessWord> GetGeneratedGuessWords(int numElements);
}
