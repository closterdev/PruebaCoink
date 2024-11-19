using Coink.Application.Dtos;

namespace Coink.Application.Interfaces.Services;

public interface IUserService
{
    Task CreateUserAsync(UserIn user);
    Task<List<UserIn>> GetAllUsersAsync();
}