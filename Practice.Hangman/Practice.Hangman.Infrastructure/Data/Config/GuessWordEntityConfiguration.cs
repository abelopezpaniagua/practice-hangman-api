using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Infrastructure.Data.Config;

public class GuessWordEntityConfiguration : IEntityTypeConfiguration<GuessWord>
{
    private readonly IDataGenerator _dataGenerator;

    public GuessWordEntityConfiguration(IDataGenerator dataGenerator)
    {
        _dataGenerator = dataGenerator;
    }

    public void Configure(EntityTypeBuilder<GuessWord> builder)
    {
        builder.ToTable("GuessWords");

        builder.ConfigureBaseEntityProperties<GuessWord, int>();

        builder.Property(x => x.Word)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(x => x.WordSize)
            .IsRequired();

        builder.Property(x => x.Difficulty)
            .IsRequired();

        var generatedWords = _dataGenerator.GetGeneratedGuessWords(850);
        builder.HasData(generatedWords);
    }
}
