using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Coink.Application.Validators;
using FluentValidation;

namespace Coink.Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<UserInValidator>();

        return services;
    }
}