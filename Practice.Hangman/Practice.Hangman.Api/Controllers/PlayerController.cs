using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Core.Dtos.Requests;
using Practice.Hangman.Core.Dtos.Responses;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Api.Controllers;

[Route("api/players")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _service;
    private readonly IMapper _mapper;

    public PlayerController(IPlayerService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPlayerById(Guid id)
    {
        var player = await _service.RetrievePlayer(id);

        if (player is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<PlayerResponseDto>(player);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlayer(CreatePlayerRequestDto request)
    {
        var player = _mapper.Map<Player>(request);
        var createdPlayer = await _service.CreatePlayer(player);

        var response = _mapper.Map<PlayerResponseDto>(createdPlayer);

        return Ok(response);
    }
}
