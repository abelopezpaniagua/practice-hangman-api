using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Infrastructure.Data.Config;

public static class BaseEntityConfigurationExtension
{
    public static void ConfigureBaseEntityProperties<TEntity, TIdentifier>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity<TIdentifier> where TIdentifier : struct
    {
        builder.HasKey(e => e.Id);

        if (typeof(TIdentifier) == typeof(Guid))
        {
            builder.Property(e => e.Id)
                .HasValueGenerator<GuidValueGenerator>();
        }
    }
}
