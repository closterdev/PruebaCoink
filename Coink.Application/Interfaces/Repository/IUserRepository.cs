using Coink.Application.Dtos;
using Coink.Domain.Entities.Controllers;

namespace Coink.Application.Interfaces.Repository;

public interface IUserRepository
{
    Task AddUserAsync(UserIn User);
    Task<List<User>> GetUsersAsync();
}