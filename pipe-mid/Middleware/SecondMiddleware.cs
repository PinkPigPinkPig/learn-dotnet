using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace pipe_mid.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        /*
            Url == "/xxx.html"
                - Khong goi Middleware phia sau
                - Khong duoc truy cap
                - Header - SecondMiddleware: Ban khong duoc truy cap
            Url !=
        */ 
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if(context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cao");
                var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if(dataFromFirstMiddleware != null)
                    await context.Response.WriteAsync((string)dataFromFirstMiddleware);
                await context.Response.WriteAsync("Ban khong duoc truy cap");
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban duoc truy cao");
                await next(context);
            }
        }
    }
}