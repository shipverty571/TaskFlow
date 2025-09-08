using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Services;
using UserService.Domain.DTOs;
using UserService.Domain.Entities;

namespace UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager _userManager;

    public UserController(UserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        await _userManager.Add(registerDto);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }
}