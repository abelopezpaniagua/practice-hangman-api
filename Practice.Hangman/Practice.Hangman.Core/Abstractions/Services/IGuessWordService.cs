using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Services;

public interface IGuessWordService
{
    Task<GuessWord> GetRandomGuessWord(int difficulty = 1);
    bool VerifyCorrectGuessChar(GuessWord guessWord, char characterToVerify);
}
