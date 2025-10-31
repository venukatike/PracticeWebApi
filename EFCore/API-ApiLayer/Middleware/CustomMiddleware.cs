using System.Text.Json;

namespace EFCore.API_ApiLayer.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                var result = JsonSerializer.Serialize(new
                {
                    error = ex.Message,
                    statusCode = context.Response.StatusCode
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
