using Coink.Application.Dtos;
using Coink.Application.Interfaces.Repository;
using Coink.Application.Interfaces.Services;
using FluentValidation;

namespace Coink.Application.Services;

public class UserService(IUserRepository repository, IValidator<UserIn> validator) : IUserService
{
    private readonly IUserRepository _repository = repository;
    private readonly IValidator<UserIn> _validator = validator;

    public async Task CreateUser(UserIn input)
    {
        var validationResult = _validator.Validate(input);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ArgumentException($"Errores de validación: {errors}");
        }

        await _repository.AddUser(input);
    }
}