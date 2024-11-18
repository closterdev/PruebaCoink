using Coink.Application.Interfaces;
using Coink.Infrastructure.Data;
using Coink.Infrastructure.Repository;
using Coink.Infrastructure.Security.Databases;
using Coink.Infrastructure.Security.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                .BindConfiguration(nameof(JwtCredentials));

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApiDbContext>(db => db.UseNpgsql(config.GetConnectionString("DbCredentials:PostgreSql")))
                .AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IRepository, Repository>();

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