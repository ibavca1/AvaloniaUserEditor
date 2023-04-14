using System.Threading.Tasks;
using AvaloniaUserEditor.Models;
using Newtonsoft.Json.Linq;
using Refit;

namespace AvaloniaUserEditor.Infrastructure;

public interface IApi
{
    [Post("/login")]
    Task<TokenDto> Login([Body] JObject user);
}