namespace HBP.api.Custom_Middlewares
{
    public class EasMiddleware
    {
        public readonly RequestDelegate _request;
        public EasMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Eas OF");
            await _request(context);
        }
    }
}
