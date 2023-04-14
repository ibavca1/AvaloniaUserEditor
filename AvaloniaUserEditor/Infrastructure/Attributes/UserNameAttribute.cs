using System.ComponentModel.DataAnnotations;

namespace AvaloniaUserEditor.Infrastructure.Attributes;

public class UserNameAttribute:ValidationAttribute
{
    private string PropertyName;
    public UserNameAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }
}