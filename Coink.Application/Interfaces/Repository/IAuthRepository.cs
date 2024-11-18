using Coink.Domain.Entities.Security.Token;

namespace Coink.Application.Interfaces.Repository;

public interface IAuthRepository
{
    Task<TokenUser?> GetUserByKeyAsync(TokenUser userCredentials);
}