using AutoMapper;
using Practice.Hangman.Core.Dtos.Responses;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Mappers;

public class PlayerGameProfile : Profile
{
    public PlayerGameProfile()
    {
        CreateMap<PlayerGame, PlayerGameResponseDto>();
    }
}
