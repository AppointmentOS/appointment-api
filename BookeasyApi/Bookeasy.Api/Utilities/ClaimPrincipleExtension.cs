using System.Security.Claims;

namespace Bookeasy.Api.Utilities
{
    public static class ClaimPrincipleExtension
    {
        public static string GetUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirstValue("UserId");
        }
    }
}
