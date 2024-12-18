using CrmApi.Middleware;

namespace CrmApi
{
    public static class NormalizeHttpContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseNormalizeHttpContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NormalizeHttpContextMiddleware>();
        }
    }
}
