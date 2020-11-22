using System.Linq;
using System.Security.Claims;

namespace Bookeasy.Api
{
    public static class ClaimPrincipleExtension
    {
        /// <summary>
        /// Get embedded user id from JWT token
        /// </summary>
        /// <param name="claim"></param>
        /// <returns>User id</returns>
        public static string GetUserId(this ClaimsPrincipal claim)
        {
            return claim.FindFirst("UserId").Value;
        }
    }
}
