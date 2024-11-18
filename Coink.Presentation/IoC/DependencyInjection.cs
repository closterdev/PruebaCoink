using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Coink.Presentation.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddServices();
        services.AddEndpointsApiExplorer();
        services.AddSwagger();
        services.AddProblemDetails();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        //services.AddSingleton<IService, Service>();

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
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

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
}