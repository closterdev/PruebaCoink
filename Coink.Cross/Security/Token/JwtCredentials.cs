﻿using System.ComponentModel.DataAnnotations;

namespace Coink.Cross.Security.Token;

public class JwtCredentials
{
    [Required]
    public string Audience { get; set; } = string.Empty;
    [Required]
    public string Issuer { get; set; } = string.Empty;
    [Required]
    public string Secret { get; set; } = string.Empty;
    [Required]
    public string User { get; set; } = string.Empty;
    [Required]
    public int ExpirationTime { get; set; }
}