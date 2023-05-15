using AutoMapper;
using Practice.Hangman.Core.Dtos.Requests;
using Practice.Hangman.Core.Dtos.Responses;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Mappers;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<CreatePlayerRequestDto, Player>();
        CreateMap<Player, PlayerResponseDto>();
    }
}
