using Practice.Hangman.Core.Abstractions.Repositories;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Domain.Entities;
using Practice.Hangman.Domain.Exceptions;

namespace Practice.Hangman.Core.Services;

public class GuessWordService : IGuessWordService
{
    private readonly IGuessWordRepository _repository;

    public GuessWordService(IGuessWordRepository repository)
    {
        _repository = repository;
    }

    public async Task<GuessWord> GetRandomGuessWord(int difficulty = 1)
    {
        var word = await _repository.RetrieveRandomGuessWordByDifficulty(difficulty);

        if (word is null)
        {
            throw new CannotRetrieveGuessWordException();
        }

        return word;
    }

    public bool VerifyCorrectGuessChar(GuessWord guessWord, char characterToVerify)
    {
        return guessWord.Word.Contains(characterToVerify);
    }
}
