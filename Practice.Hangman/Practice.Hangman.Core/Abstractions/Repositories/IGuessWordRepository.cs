using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Abstractions.Repositories;

public interface IGuessWordRepository : IRepository<GuessWord, int>
{
    Task<GuessWord?> RetrieveRandomGuessWordByDifficulty(int dificulty); 
}
