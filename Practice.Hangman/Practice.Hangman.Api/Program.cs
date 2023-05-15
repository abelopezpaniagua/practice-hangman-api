using Practice.Hangman.Api.Middlewares;
using Practice.Hangman.Core;
using Practice.Hangman.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject Infra dependencies
builder.Host.AddLogger();

builder.Services
    .AddPersistence(builder.Configuration)
    .AddExternalServices();

// Inject Core dependencies
builder.Services
    .AddServices()
    .AddMappers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
