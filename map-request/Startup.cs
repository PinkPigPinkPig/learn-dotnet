using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using map_request.mylib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace map_request
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                        HtmlHelper.DefaultMenuTopItems(), context.Request
                    );
                    var html = HtmlHelper.HtmlDocument("Xin chao", menu + HtmlHelper.HtmlTrangchu());
                    await context.Response.WriteAsync(html);
                });
                
                endpoints.MapGet("/RequestInfo", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                        HtmlHelper.DefaultMenuTopItems(), context.Request
                    );
                    var info = RequestProcess.RequestInfo(context.Request).HtmlTag("div", "container");
                    var html = HtmlHelper.HtmlDocument("Thông tin request", menu + info);
                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/Encoding", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                        HtmlHelper.DefaultMenuTopItems(), context.Request
                    );
                    var p = new {
                        Name = "Watch",
                        Price = "300000",
                        CreatedOn = "CreatedOn"
                    };
                    var json = JsonConvert.SerializeObject(p);
                    // var html = HtmlHelper.HtmlDocument("JSON", menu + json);
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(json);
                });

                endpoints.MapGet("/Cookies", async context =>
                {
                    await context.Response.WriteAsync("Cookies");
                });

                endpoints.MapGet("/Json", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                        HtmlHelper.DefaultMenuTopItems(), context.Request
                    );
                    var p = new {
                        Name = "Watch",
                        Price = "300000",
                        CreatedOn = "CreatedOn"
                    };
                    var json = JsonConvert.SerializeObject(p);
                    // var html = HtmlHelper.HtmlDocument("JSON", menu + json);
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(json);
                });

                endpoints.MapGet("/Form", async context =>
                {
                    await context.Response.WriteAsync("Form");
                });
            });
        }
    }
}
