using Coink.Application.Dtos;
using Coink.Application.Interfaces.Repository;
using Coink.Application.Interfaces.Services;
using Coink.Cross.Common;
using Coink.Domain.Entities.Security.Token;
using System.Text;

namespace Coink.Application.Services;

public class AuthService(IAuthRepository auth, ITokenService token) : IAuthService
{
    private readonly IAuthRepository _authRepository = auth;
    private readonly ITokenService _tokenService = token;

    public async Task<TokenOut> ValidateUser(TokenIn userCredentials)
    {
        try
        {
            string? token = null;
            TokenUser CredentialsDto = MapUserToEntity(userCredentials);
            TokenUser? dataUser = await _authRepository.GetUserByKeyAsync(CredentialsDto);

            if (dataUser != null)
            {
                if (!dataUser.IsActive)
                {
                    return new TokenOut { Message = "El username esta inactivo.", Result = Result.IsNotActive, Token = token };
                }

                bool isValid = PassCheck(dataUser, userCredentials);
                token = isValid ? _tokenService.JwtToken() : null;

                return isValid
                    ? new TokenOut { Message = "El token se genero correctamente.", Result = Result.Success, Token = token }
                    : new TokenOut { Message = "La password es incorrecta.", Result = Result.InvalidPassword, Token = token };
            }
            else
            {
                return new TokenOut { Message = "El username no existe.", Result = Result.NoRecords, Token = token };
            }
        }
        catch (Exception ex)
        {
            return new TokenOut { Message = $"Ha ocurrido un error. {ex.Message}", Result = Result.Error };
        }
    }

    private static bool PassCheck(TokenUser data, TokenIn user)
    {
        try
        {
            byte[] bytes = Encoding.UTF8.GetBytes(user.Password);
            string encodedPassword = Convert.ToBase64String(bytes);

            return string.Equals(encodedPassword, data.Password, StringComparison.Ordinal);
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static TokenUser MapUserToEntity(TokenIn user)
    {
        return new TokenUser()
        {
            Username = user.Username,
            Password = user.Password
        };
    }
}