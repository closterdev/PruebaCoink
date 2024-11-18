namespace Coink.Domain.Entities.Security.Token;

public class TokenUser
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}