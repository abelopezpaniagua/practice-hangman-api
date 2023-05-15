using Practice.Hangman.Domain.Constants;
using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Domain.Entities;

public class PlayerGame : BaseEntity<Guid>
{
    public Guid PlayerId { get; set; }
    public int GuessWordId { get; set; }
    public long CurrentScore { get; set; }
    public int TotalAttempts { get; set; }
    public ICollection<char> AttemptedChars { get; set; } = new List<char>();
    public int SuccessfulAttempts { get; set; }
    public ICollection<char> GuessedChars { get; set; } = new List<char>();
    public GameStatus Status { get; set; }
    public DateTimeOffset? StartAt { get; set; }
    public DateTimeOffset? FinishedAt { get; set; }

    public Player Player { get; set; } = default!;
    public GuessWord GuessWord { get; set; } = default!;

    public int WrongAttempts => TotalAttempts - SuccessfulAttempts;
    public int RemainingAttempts => GameConstants.MaxAttempts - WrongAttempts;
    public long? GuessedWordTimeElapsed {
        get {
            if (!StartAt.HasValue || !FinishedAt.HasValue)
            {
                return null;
            }

            return (long)(FinishedAt - StartAt).Value.TotalMilliseconds;
        }
    }
    public int AttemptScore => GuessWord.Difficulty * GameConstants.ScorePerCorrectAttempt;

    public bool WordIsGuessed
    {
        get
        {
            var wordCharacters = GuessWord.Word.ToCharArray();
            var remainingCharactersToGuess = wordCharacters.Except(GuessedChars);

            return !remainingCharactersToGuess.Any();
        }
    }
}
