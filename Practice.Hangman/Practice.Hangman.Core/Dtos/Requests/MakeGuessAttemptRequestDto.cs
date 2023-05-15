namespace Practice.Hangman.Core.Dtos.Requests;

public class MakeGuessAttemptRequestDto
{
    public string CharacterToGuess { get; set; } = string.Empty;
}
