using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Domain.Entities;
using System.Reflection;

namespace Practice.Hangman.Infrastructure.Data.DataGenerators;

public class CustomDataGenerator : IDataGenerator
{
    private readonly string _fileName = @"AvailableWords.txt";
    private readonly string[] _availableWords;
    
    public CustomDataGenerator()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), _fileName);
        _availableWords = File.ReadAllLines(filePath);
    }

    public ICollection<GuessWord> GetGeneratedGuessWords(int numElements)
    {
        var wordIndexes = Enumerable.Range(1, numElements)
            .ToList();

        return wordIndexes.Select(index => GenerateWord(index))
            .ToList();
    }

    private GuessWord GenerateWord(int index)
    {
        var word = _availableWords[index];

        return new GuessWord
        {
            Id = index,
            Word = word,
            WordSize = word.Length,
            Difficulty = GuessWord.GetWordDifficulty(word)
        };
    }
}
