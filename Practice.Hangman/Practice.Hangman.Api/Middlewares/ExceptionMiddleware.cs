using Practice.Hangman.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Practice.Hangman.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error happened :: {Message} :: {Exception}", ex.Message, ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex is AbstractException && (ex as AbstractException)!.Severity <= Domain.Enums.ExceptionSeverity.Error 
            ? (int)HttpStatusCode.BadRequest 
            : (int)HttpStatusCode.InternalServerError;
        var message = ex is AbstractException && (ex as AbstractException)!.Severity <= Domain.Enums.ExceptionSeverity.Error
            ? (ex as AbstractException)!.FriendlyMessage
            : "Internal Server Error";

        var response = new
        {
            Status = context.Response.StatusCode,
            Message = message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
