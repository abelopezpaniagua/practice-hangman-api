using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Hangman.Core.Abstractions.Services;
using Practice.Hangman.Core.Dtos.Responses;

namespace Practice.Hangman.Api.Controllers
{
    [Route("api/scores")]
    [ApiController]
    public class PlayerScoreController : ControllerBase
    {
        private IPlayerScoreService _service;
        private IMapper _mapper;

        public PlayerScoreController(IPlayerScoreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboardScores(int difficulty = 1, int page = 1, int size = 20)
        {
            var scores = await _service.GetPlayerScores(difficulty, page, size);

            var response = _mapper.Map<List<PlayerScoreResponseDto>>(scores);

            return Ok(response);
        }
    }
}
