using Coink.Domain.Entities.Controllers;

namespace Coink.Application.Interfaces.Services;

public interface IUserService
{
    Task<bool> CreateUser(User user);
}