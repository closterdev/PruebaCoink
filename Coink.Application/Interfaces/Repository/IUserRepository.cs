using Coink.Application.Dtos;

namespace Coink.Application.Interfaces.Repository;

public interface IUserRepository
{
    Task AddUser(UserIn User);
}