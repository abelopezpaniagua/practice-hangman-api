using Microsoft.EntityFrameworkCore;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Infrastructure.Data.Config;
using System.Reflection;

namespace Practice.Hangman.Infrastructure.Data;

public class GameDbContext : DbContext
{
    protected readonly IDataGenerator _dataGenerator;

    public GameDbContext(DbContextOptions<GameDbContext> options, IDataGenerator dataGenerator) : base(options)
    {
        _dataGenerator = dataGenerator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GuessWordEntityConfiguration(_dataGenerator));
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
