using AvaloniaUserEditor.Models;

namespace AvaloniaUserEditor.Infrastructure;

public static class Extensions
{
    public static Token ToToken(this TokenDto tokenDto)
    {
        return new Token
        {
            Value = tokenDto.Token,
            Expiration = tokenDto.Expiration
        };
    }
}