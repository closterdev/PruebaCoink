using Coink.Application.Interfaces.Repository;
using Coink.Infrastructure.Data;
using Coink.Infrastructure.Repository;
using Coink.Cross.Security.Databases;
using Coink.Cross.Security.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Coink.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddJwtConfig()
                .AddDbConfig()
                .AddPersistence(config)
                .AddJwtAuthentication()
                .AddJwtAuthorization();

        return services;
    }

    private static IServiceCollection AddDbConfig(this IServiceCollection services)
    {
        services.AddOptions<DbCredentials>()
                .BindConfiguration(nameof(DbCredentials));

        return services;
    }

    private static IServiceCollection AddJwtConfig(this IServiceCollection services)
    {
        services.AddOptions<JwtCredentials>()
                .BindConfiguration(nameof(JwtCredentials))
                .ValidateDataAnnotations()
                .ValidateOnStart();

        return services;
    }

    private static IServiceCollection AddDbConnection(this IServiceCollection services)
    {
        services.AddOptions<DbCredentials>()
                .BindConfiguration(nameof(DbCredentials))
                .ValidateDataAnnotations()
                .ValidateOnStart();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApiDbContext>((sp, db) => 
                    db.UseNpgsql(
                        sp.GetRequiredService<IOptions<DbCredentials>>().Value.PostgreSql))
                .AddScoped<IAuthRepository, TokenUserRepository>()
                .AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

        return services; 
    }

    private static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization();

        return services;
    }
}