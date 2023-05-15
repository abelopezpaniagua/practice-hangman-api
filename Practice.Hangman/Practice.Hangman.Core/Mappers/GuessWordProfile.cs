using AutoMapper;
using Practice.Hangman.Core.Dtos.Responses;
using Practice.Hangman.Domain.Entities;

namespace Practice.Hangman.Core.Mappers;

public class GuessWordProfile : Profile
{
    public GuessWordProfile()
    {
        CreateMap<GuessWord, GuessWordResponseDto>();
    }
}
