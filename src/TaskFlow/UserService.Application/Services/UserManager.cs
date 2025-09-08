using AutoMapper;
using UserService.Domain.DTOs;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services;

public class UserManager
{
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task Add(RegisterDto registerDto)
    {
        var user = _mapper.Map<User>(registerDto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        await _userRepository.Create(user);
    }

    public async Task<User?> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmail(loginDto.Email);
        if (user == null
            || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }
}