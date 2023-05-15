using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Infrastructure.Data.Config;

public class PlayerEntityConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");

        builder.ConfigureBaseEntityProperties<Player, Guid>();

        builder.Property(x => x.Nickname)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(x => x.AvatarUrl)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.Property(x => x.Rank)
            .IsRequired();

        builder.Property(x => x.RegisteredDate)
            .IsRequired();
    }
}
