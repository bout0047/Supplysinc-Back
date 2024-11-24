using System.Security.Claims;

namespace SupplySyncBackend.Utilities
{
    public static class RoleChecker
    {
        public static bool IsUserInRole(ClaimsPrincipal user, string role)
        {
            return user.IsInRole(role);
        }

        public static bool HasClaim(ClaimsPrincipal user, string claimType, string claimValue)
        {
            return user.HasClaim(claimType, claimValue);
        }
    }
}
