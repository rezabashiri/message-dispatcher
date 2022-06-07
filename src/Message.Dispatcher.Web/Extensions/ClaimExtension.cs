using System.Security.Claims;

namespace Message.Dispatcher.Web.Extensions
{
    public static class ClaimExtension
    {
        public static string GetUserFamily(this ClaimsPrincipal user)
        {
            return user.Claims.First(x => x.Type == "family_name")?.Value;
        }
    }
}
