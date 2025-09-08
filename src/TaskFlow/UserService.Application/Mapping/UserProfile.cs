using AutoMapper;
using UserService.Domain.DTOs;
using UserService.Domain.Entities;

namespace UserService.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }
}