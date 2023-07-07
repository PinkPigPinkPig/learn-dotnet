using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace hello_asp
{
    public class MyStartup
    {
        // Register services for app
        public void ConfigServices(IServiceCollection services)
        {
            // services.AddSingleTon
        }

        // Build pipeline (middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //EndPointRoutingMiddleware
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/", async (context) => {
                    await context.Response.WriteAsync("trang chu");
                });
            });

            //Terminate middleware
            app.Map("/abc", app1 => {
                app1.Run(async (HttpContext context) => {
                await context.Response.WriteAsJsonAsync("Hello World abc");
                });
            });

            //Terminate middleware
            app.Run(async (HttpContext context) => {
                await context.Response.WriteAsJsonAsync("Hello World");
            });
        }
    }
}