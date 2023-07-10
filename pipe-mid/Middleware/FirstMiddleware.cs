using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace pipe_mid.Middleware
{
    public class FirstMiddleware
    {   
        private readonly RequestDelegate _next;
        // RequestDelegate ~ async (HttpContext context) => {}
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        // Http di qua midddleware trong pipeline
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(context.Request.Path);
            context.Items.Add("DataFirstMiddleware", $"<p>{context.Request.Path}</p>");
            // await context.Response.WriteAsync($"<p>{context.Request.Path}</p>");
            await _next(context);
        }
    }
}