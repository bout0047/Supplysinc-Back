using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySyncBackend.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Authentication token is missing.");
                return;
            }

            // Token validation logic
            if (!ValidateToken(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid authentication token.");
                return;
            }

            await _next(context);
        }

        private bool ValidateToken(string token)
        {
            // Replace with your token validation logic (e.g., JWT validation)
            return !string.IsNullOrEmpty(token); // Simplified example
        }
    }
}
