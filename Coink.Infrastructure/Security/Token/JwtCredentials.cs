namespace Coink.Infrastructure.Security.Token;

public record JwtCredentials(
    string Audience, 
    string Issuer, 
    string Secret, 
    string User,
    int ExpirationTime);