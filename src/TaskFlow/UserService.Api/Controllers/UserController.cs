using Microsoft.AspNetCore.Mvc;
using UserService.Api.Factories;
using UserService.Application.Services;
using UserService.Domain.DTOs;

namespace UserService.Api.Controllers;

[ApiController]
[Route("auth")]
public class UserController : ControllerBase
{
    private readonly UserManager _userManager;

    private readonly IConfiguration _configuration;

    public UserController(UserManager userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        await _userManager.Add(registerDto);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.Login(loginDto);
        if (user == null) return Unauthorized();

        var jwt = JwtFactory.Generate(user, _configuration);
        return Ok(new { Token = jwt });
    }
}