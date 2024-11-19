using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Coink.Application.Validators;

namespace Coink.Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddFluentValidation(config =>
        {
            config.RegisterValidatorsFromAssemblyContaining<UserInValidator>();
            config.DisableDataAnnotationsValidation = true;
        });

        return services;
    }
}