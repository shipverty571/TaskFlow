using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces;

public interface IUserRepository
{
    Task Create(User user);

    Task<User?> GetByEmail(string email);
}