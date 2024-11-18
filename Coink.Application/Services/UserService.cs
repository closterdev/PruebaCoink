using Coink.Application.Interfaces.Repository;
using Coink.Application.Interfaces.Services;
using Coink.Domain.Entities.Controllers;

namespace Coink.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateUser(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name) ||
            string.IsNullOrWhiteSpace(user.Phone) ||
            string.IsNullOrWhiteSpace(user.Address))
        {
            throw new ArgumentException("Los campos nombre, teléfono y dirección son obligatorios.");
        }

        return await _repository.InsertUser(user);
    }
}