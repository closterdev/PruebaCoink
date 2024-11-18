using Coink.Domain.Entities;

namespace Coink.Application.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByKeyAsync(User userCredentials);
}