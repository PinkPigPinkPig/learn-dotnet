using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace hello_asp
{
    public class Program
    {
        /*
            Host (IHost) object:
                - Dependency Injection(DI): IServiceProvider (ServiceCollection)
                - Logging (ILogging)
                - Configuration
                - IHostedService => StartAsync : Run HTTP Server (Kestrel Http)

            1) Create IHostBuilder
            2) Config, Register service (call ConfigureWebHostDefaults)
            3) IHostBuilder.Build() => Host (IHost)
            4) Host.Run()
        */
        public static void Main(string[] args)
        {
            Console.WriteLine("Start Up!");
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            // Config default for Host
            builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) => {
                // options config
                webBuilder.UseStartup<MyStartup>();
            });

            IHost host = builder.Build();
            host.Run();
        }
        // public static void Main(string[] args)
        // {
        //     CreateHostBuilder(args).Build().Run();
        // }

        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
    }
}
