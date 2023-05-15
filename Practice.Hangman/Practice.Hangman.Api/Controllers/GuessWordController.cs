using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Core.Dtos.Responses;

namespace Practice.Hangman.Api.Controllers;

[Route("api/words")]
[ApiController]
public class GuessWordController : ControllerBase
{
    private readonly IGuessWordService _service;
    private readonly ILogger<GuessWordController> _logger;
    private readonly IMapper _mapper;

    public GuessWordController(IGuessWordService service, ILogger<GuessWordController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRandomWord(int difficulty = 1)
    {
        var word = await _service.GetRandomGuessWord(difficulty);

        _logger.LogInformation("Random word retrieved: {Word}", word);

        var response = _mapper.Map<GuessWordResponseDto>(word);

        return Ok(response);
    }
}
