namespace Practice.Hangman.Core.Dtos.Responses;

public class GuessWordResponseDto
{
    public string Word { get; set; } = string.Empty;
    public int WordSize { get; set; }
    public int Difficulty { get; set; }
}
