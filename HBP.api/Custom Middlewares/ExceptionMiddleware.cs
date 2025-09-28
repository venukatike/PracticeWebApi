public class ExceptionMiddleware
{
	public readonly RequestDelegate _next;
	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task InvokeAsync(HttpContext context)
	{

		try {
			await _next(context);
		}
		catch(Exception ex)
		{
			//if (context.Response.StatusCode == 500) {
				await context.Response.WriteAsJsonAsync(new { ex.Message });
			//}
		}
	}
}