using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaUserEditor.Infrastructure.Validators;

public class LoginForm:ObservableValidator
{
    private IShared _shared;

    public LoginForm(IShared shared)
    {
        _shared = shared;
    }
    
    private string userName;

    [Required]
    [MinLength(1)]
    public string UserName
    {
        get => userName;
        set
        {
            SetProperty(ref userName, value, true);
        }
    }

    public static ValidationResult? ValidateUserName(string name, string password, ValidationContext context)
    {
        LoginForm instance = (LoginForm)context.ObjectInstance;
        var result = instance._shared.ValidateUser(name, password);
        if(result.IsValid)
        {
            return ValidationResult.Success;
        }

        return new("1");
    }
}