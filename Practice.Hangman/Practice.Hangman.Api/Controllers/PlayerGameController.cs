using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Core.Dtos.Requests;
using Practice.Hangman.Core.Dtos.Responses;

namespace Practice.Hangman.Api.Controllers;

[Route("api/games")]
[ApiController]
public class PlayerGameController : ControllerBase
{
    private readonly IPlayerGameService _service;
    private readonly IMapper _mapper;

    public PlayerGameController(IPlayerGameService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayerGame(Guid id)
    {
        var playerGame = await _service.RetrievePlayerGame(id);

        if (playerGame is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<PlayerGameResponseDto>(playerGame);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> InitializeGame(InitializeGameRequestDto request)
    {
        var playerGame = await _service.InitializePlayerGame(request.PlayerId, request.GameDifficulty);
        var response = _mapper.Map<PlayerGameResponseDto>(playerGame);

        return Ok(response);
    }

    [Route("{id}/active")]
    [HttpPatch]
    public async Task<IActionResult> ActivateGame(Guid id)
    {
        var playerGame = await _service.ActivePlayerGame(id);
        var response = _mapper.Map<PlayerGameResponseDto>(playerGame);

        return Ok(response);
    }

    [Route("{id}/guess")]
    [HttpPost]
    public async Task<IActionResult> MakeWordGuessAttempt(Guid id, [FromBody] MakeGuessAttemptRequestDto request)
    {
        var playerGame = await _service.MakeGuessAttempt(id, request.CharacterToGuess);
        var response = _mapper.Map<PlayerGameResponseDto>(playerGame);

        return Ok(response);
    }
}
