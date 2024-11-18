using Coink.Application.Dtos;

namespace Coink.Application.Interfaces.Services;

public interface IAuthService
{
    Task<TokenOut> ValidateUser(TokenIn userCredentials);
}