using AvaloniaUserEditor.Models;

namespace AvaloniaUserEditor.Infrastructure;

public interface IShared
{
    public ValidateUserResult ValidateUser(string name, string password);
}