using Practice.Hangman.Domain.Enums;

namespace Practice.Hangman.Core.Dtos.Responses;

public class PlayerGameResponseDto
{
    public Guid Id { get; set; }
    public Guid PlayerId { get; set; }
    public long CurrentScore { get; set; }
    public int TotalAttempts { get; set; }
    public int SuccessfulAttempts { get; set; }
    public int WrongAttempts { get; set; }
    public int RemainingAttempts { get; set; }
    public ICollection<char> AttemptedChars { get; set; } = new List<char>();
    public ICollection<char> GuessedChars { get; set; } = new List<char>();
    public GameStatus Status { get; set; }
    public DateTimeOffset? StartAt { get; set; }
    public DateTimeOffset? FinishedAt { get; set; }
    public long? GuessedWordTimeElapsed { get; set; }

    public PlayerResponseDto Player { get; set; } = default!;
    public GuessWordResponseDto GuessWord { get; set; } = default!;

    public bool WordIsGuessed { get; set; }
}
