using Coink.Application.Dtos;

namespace Coink.Application.Interfaces.Services;

public interface IUserService
{
    Task CreateUser(UserIn user);
}