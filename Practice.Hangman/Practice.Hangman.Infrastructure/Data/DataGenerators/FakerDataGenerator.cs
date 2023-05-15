using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Domain.Entities;
using Bogus;

namespace Practice.Hangman.Infrastructure.Data.DataGenerators;

public class FakerDataGenerator : IDataGenerator
{
    public ICollection<GuessWord> GetGeneratedGuessWords(int numElements)
    {
        var generator = GetGuessWordGenerator();
        return generator.Generate(numElements);
    }

    private static Faker<GuessWord> GetGuessWordGenerator()
    {
        return new Faker<GuessWord>()
            .RuleFor(gw => gw.Id, f => f.Random.Number(0, 100000))
            .RuleFor(gw => gw.Word, f => f.Random.Word())
            .RuleFor(gw => gw.WordSize, f => f.Random.Word().Length)
            .RuleFor(gw => gw.Difficulty, f => GuessWord.GetWordDifficulty(f.Random.Word()));
    }
}
