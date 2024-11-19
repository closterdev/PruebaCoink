using Coink.Application.Interfaces.Services;
using Coink.Application.Services;
using Coink.Cross.Security.Databases;
using Coink.Infrastructure.Services.Security;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Coink.Presentation.IoC;

/// <summary>
/// 
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer()
                .AddCorsCustom()
                .AddServices()
                .AddSwagger()
                .AddProblemDetails()
                .AddChecks();

        return services;
    }

    private static IServiceCollection AddCorsCustom(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowCors", policy =>
                policy.WithOrigins("*")
                      .AllowAnyMethod()
                      .AllowAnyHeader());
        });

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ITokenService, TokenService>();

        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "CoinkAPI",
                Description = "Test Service - Web API for managing Users",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Martinez - Contact",
                    Url = new Uri("https://linkedin.com/in/javierski")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://example.com/license")
                }
            });
            
            options.IncludeXmlComments(Path.Combine(
                    AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}.",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                Array.Empty<string>()
                }
            });
        });

        return services;
    }

    private static IServiceCollection AddChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
                .AddNpgSql(sp =>
                    sp.GetRequiredService<IOptions<DbCredentials>>().Value.PostgreSql,
                    name: "PostgreSQL",
                    tags: ["database", "critical"]
                );

        return services;
    }
}