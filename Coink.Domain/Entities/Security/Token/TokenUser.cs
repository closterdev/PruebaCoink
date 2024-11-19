using System.ComponentModel.DataAnnotations.Schema;

namespace Coink.Domain.Entities.Security.Token;

public class TokenUser
{
    [Column("username")]
    public string Username { get; set; } = string.Empty;
    [Column("password")]
    public string Password { get; set; } = string.Empty;
    [Column("isActive")]
    public bool IsActive { get; set; }
}