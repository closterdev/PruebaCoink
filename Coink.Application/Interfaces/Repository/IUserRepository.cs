using Coink.Domain.Entities.Controllers;

namespace Coink.Application.Interfaces.Repository;

public interface IUserRepository
{
    Task<bool> InsertUser(User User);
}