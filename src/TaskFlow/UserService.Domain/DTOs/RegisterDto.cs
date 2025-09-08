namespace UserService.Domain.DTOs;

public record RegisterDto
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}