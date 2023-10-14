using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Iconic.Service.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
    public static int? UserId => GetUserId();
    public static string UserRole => HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;

    private static int? GetUserId()
    {
        string value = HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;

        bool canParse = int.TryParse(value, out int id);
        return canParse ? id : null;
    }
}
