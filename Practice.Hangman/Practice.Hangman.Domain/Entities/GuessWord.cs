namespace Practice.Hangman.Domain.Entities;

public class GuessWord : BaseEntity<int>
{
    public string Word { get; set; } = string.Empty;
    public int WordSize { get; set; }
    public int Difficulty { get; set; }

    public static int GetWordDifficulty(string word)
    {
        return word.Length / 3;
    }
}
