using System.ComponentModel.DataAnnotations;

namespace UserService.Domain.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}