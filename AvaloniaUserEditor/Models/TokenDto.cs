using System;

namespace AvaloniaUserEditor.Models;

public class TokenDto
{
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
}