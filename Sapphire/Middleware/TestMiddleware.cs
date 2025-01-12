namespace Sapphire.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
        public TestMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {

            var test = context.Request;
            await _next(context);
        }
    }
    public static class TestMiddlewareExtensions
    {
        public static IApplicationBuilder UseTestMiddleware(this IApplicationBuilder app)
        {

            return app.UseMiddleware<TestMiddleware>();
        }
    }
}
