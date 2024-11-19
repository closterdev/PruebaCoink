using Coink.Application.Dtos;
using FluentValidation;

namespace Coink.Application.Validators;

public class UserInValidator : AbstractValidator<UserIn>
{
    public UserInValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .Length(3, 20).WithMessage("El nombre debe tener entre 3 y 20 caracteres.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("El teléfono es obligatorio.")
            .Matches(@"^\d+$").WithMessage("El teléfono solo debe contener números.")
            .Length(3, 12).WithMessage("El nombre debe tener entre 3 y 12 caracteres.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("La dirección es obligatoria.")
            .Matches(@"^[0-9a-zA-Z#°.\- ]+$").WithMessage("La dirección permite solo caracteres (# . - °).")
            .MaximumLength(50).WithMessage("La dirección no debe superar los 50 caracteres.");

        RuleFor(x => x.City_id)
            .GreaterThan(0).WithMessage("El Municipio_Id debe ser mayor a 0.");
    }
}