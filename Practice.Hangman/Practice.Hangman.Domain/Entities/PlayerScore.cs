namespace Practice.Hangman.Domain.Entities;

public class PlayerScore : BaseEntity<int>
{
    public Guid PlayerId { get; set; }
    public int Rank { get; set; }
    public int Difficulty { get; set; }
    public long Score { get; set; }
    public int NumAttempts { get; set; }
    public long MinTimeWordGuessed { get; set; }

    public Player Player { get; set; } = default!;
}
