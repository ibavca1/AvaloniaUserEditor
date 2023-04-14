using AvaloniaUserEditor.Models;
using Newtonsoft.Json.Linq;
using Refit;

namespace AvaloniaUserEditor.Infrastructure;

public class Shared: IShared
{
    public RefitSettings JsonSetting { get; }
    public IApi Api { get; }

    public Shared()
    {
        JsonSetting = new RefitSettings(new NewtonsoftJsonContentSerializer());
        Api = RestService.For<IApi>("http://172.24.6.63:8000", JsonSetting);
    }
    public ValidateUserResult ValidateUser(string name, string password)
    {
        var user = new JObject
        {
            ["UserName"] = name,
            ["Password"] = password
        };
        var token = Api.Login(user).Result;
        if (token is null)
        {
            return new ValidateUserResult
            {
                IsValid = false,
                Message = "Invalid user name or password."
            };
        }
        return new ValidateUserResult
        {
            IsValid = true,
            Message = "Ok"
        };
    }
}