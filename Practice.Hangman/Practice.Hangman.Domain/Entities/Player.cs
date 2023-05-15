namespace Practice.Hangman.Domain.Entities;

public class Player : BaseEntity<Guid>
{
    public string Nickname { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public int Rank { get; set; }
    public DateTimeOffset RegisteredDate { get; set; }
}
