using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SupplySyncBackend.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            // Log the incoming request
            LogRequest(context);

            await _next(context);

            stopwatch.Stop();

            // Log the outgoing response
            LogResponse(context, stopwatch.ElapsedMilliseconds);
        }

        private void LogRequest(HttpContext context)
        {
            var request = context.Request;
            Console.WriteLine($"Incoming Request: {request.Method} {request.Path}");
        }

        private void LogResponse(HttpContext context, long elapsedTime)
        {
            var response = context.Response;
            Console.WriteLine($"Outgoing Response: {response.StatusCode} (Processed in {elapsedTime}ms)");
        }
    }
}
