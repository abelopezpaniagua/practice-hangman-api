using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Hangman.Domain.Entities;
using System.Linq.Expressions;

namespace Practice.Hangman.Infrastructure.Data.Config;

public class PlayerGameEntityConfiguration : IEntityTypeConfiguration<PlayerGame>
{
    public void Configure(EntityTypeBuilder<PlayerGame> builder)
    {
        builder.ToTable("PlayerGames");

        builder.ConfigureBaseEntityProperties<PlayerGame, Guid>();

        builder.Property(pg => pg.PlayerId)
            .IsRequired();

        builder.Property(pg => pg.GuessWordId)
            .IsRequired();

        builder.Property(pg => pg.CurrentScore)
            .IsRequired();

        builder.Property(pg => pg.TotalAttempts)
            .IsRequired();

        builder.Property(pg => pg.SuccessfulAttempts)
            .IsRequired();

        builder.Property(pg => pg.Status)
            .IsRequired();

        builder.Property(pg => pg.StartAt)
            .IsRequired(false);

        builder.Property(pg => pg.FinishedAt)
            .IsRequired(false);

        builder.Property(pg => pg.AttemptedChars)
            .IsRequired()
            .HasConversion(chars => new string(chars.ToArray()),
                str => str.ToCharArray().ToList());

        builder.Property(pg => pg.GuessedChars)
            .IsRequired()
            .HasConversion(chars => new string(chars.ToArray()),
                str => str.ToCharArray().ToList());

        builder.HasOne(pg => pg.Player)
            .WithMany()
            .HasForeignKey(pg => pg.PlayerId);

        builder.HasOne(pg => pg.GuessWord)
            .WithMany()
            .HasForeignKey(pg => pg.GuessWordId);
    }
}
