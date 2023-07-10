using Microsoft.AspNetCore.Builder;

namespace pipe_mid.Middleware
{
    public static class UseFirstMiddlewareMethod
    {
        public static void UseFirstMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
        public static void UseSecondMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
    }
}