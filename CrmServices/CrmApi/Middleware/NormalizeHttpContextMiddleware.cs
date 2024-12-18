namespace CrmApi.Middleware
{
    public class NormalizeHttpContextMiddleware
    {
        private readonly RequestDelegate _next;

        public NormalizeHttpContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Normalize the request path to lowercase
            context.Request.Path = context.Request.Path.ToString().ToLowerInvariant();

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
