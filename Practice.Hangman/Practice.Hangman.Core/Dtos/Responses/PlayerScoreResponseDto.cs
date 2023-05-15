namespace Practice.Hangman.Core.Dtos.Responses;

public class PlayerScoreResponseDto
{
    public int Rank { get; set; }
    public int Difficulty { get; set; }
    public long Score { get; set; }
    public int NumAttempts { get; set; }
    public long MinTimeWordGuessed { get; set; }

    public PlayerResponseDto Player { get; set; } = default!;
}
