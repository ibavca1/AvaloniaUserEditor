using System;

namespace AvaloniaUserEditor.Models;

public class Token
{
    public string Value { get; set; }
    public DateTime Expiration { get; set; }
}