using System;
using System.Net.Http;
using AvaloniaUserEditor.Models;
using Newtonsoft.Json.Linq;
using Refit;

namespace AvaloniaUserEditor.Infrastructure;

public class Shared: IShared
{
    public RefitSettings JsonSetting { get; }
    public IApi Api { get; }

    public Token Token { get; set; }
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
        TokenDto? tokenDto = null;
        try
        {
            tokenDto = Api.Login(user).Result;
        }
        catch (Exception e)
        {
            return new ValidateUserResult
            {
                IsValid = false,
                Message = e.Message //"Invalid user name or password."
            };
        }
        
        this.Token = tokenDto.ToToken();
        return new ValidateUserResult
        {
            IsValid = true,
            Message = "200"
        };
    }
}