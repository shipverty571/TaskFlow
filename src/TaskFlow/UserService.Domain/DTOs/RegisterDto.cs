namespace UserService.Domain.DTOs;

public class RegisterDto
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}