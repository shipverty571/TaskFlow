using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddDataBase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(
            x =>
            {
                x.UseNpgsql("Host=localhost;Database=TaskFlowDb;Username=postgres;Password=12345");
            });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}