namespace Practice.Hangman.Core.Dtos.Requests;

public class InitializeGameRequestDto
{
    public Guid PlayerId { get; set; }
    public int GameDifficulty { get; set; }
}
