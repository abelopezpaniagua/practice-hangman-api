namespace Practice.Hangman.Core.Dtos.Responses;

public class PlayerResponseDto
{
    public Guid Id { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public int Rank { get; set; }
}
