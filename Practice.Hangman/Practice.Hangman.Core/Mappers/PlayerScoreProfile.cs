using AutoMapper;
using Practice.Hangman.Core.Dtos.Responses;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Mappers;

public class PlayerScoreProfile : Profile
{
    public PlayerScoreProfile()
    {
        CreateMap<PlayerScore, PlayerScoreResponseDto>();
    }
}
