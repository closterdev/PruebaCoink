using Coink.Presentation.IoC;
using Coink.Application.IoC;
using Coink.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowCors");
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/api/health");
app.Run();