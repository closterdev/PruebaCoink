using Microsoft.Extensions.DependencyInjection;

namespace Coink.Application.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}