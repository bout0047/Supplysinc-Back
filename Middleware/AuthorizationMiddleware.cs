using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySyncBackend.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

            if (string.IsNullOrEmpty(userRole) || !IsAuthorized(userRole))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access denied. You do not have permission to perform this action.");
                return;
            }

            await _next(context);
        }

        private bool IsAuthorized(string role)
        {
            // Define roles that are authorized to access
            var authorizedRoles = new[] { "Admin", "Manager" };
            return authorizedRoles.Contains(role);
        }
    }
}
