using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Infrastructure.Data.Config;

public class PlayerScoreEntityConfiguration : IEntityTypeConfiguration<PlayerScore>
{
    public void Configure(EntityTypeBuilder<PlayerScore> builder)
    {
        builder.ToTable("PlayerScores");

        builder.ConfigureBaseEntityProperties<PlayerScore, int>();

        builder.Property(pc => pc.PlayerId)
            .IsRequired();

        builder.Property(pc => pc.Rank)
            .IsRequired();

        builder.Property(pc => pc.Difficulty)
            .IsRequired();

        builder.Property(pc => pc.Score)
            .IsRequired();

        builder.Property(pc => pc.NumAttempts)
            .IsRequired();

        builder.Property(pc => pc.MinTimeWordGuessed)
            .IsRequired();

        builder.HasOne(pc => pc.Player)
            .WithMany()
            .HasForeignKey(pc => pc.PlayerId);
    }
}
