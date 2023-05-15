using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Models;

public class GuessWordAttemptRequest
{
    public PlayerGame PlayerGame { get; set; }
    public string GuessCharacter { get; set; } = string.Empty;
}
