namespace core_overview;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
/*
    Host (IHost) object:
        - Dependency Injection (DI): IServiceProvider (ServiceCollection)
        - Logging (ILogging)
        - Configuration
        - IHostedService => StartAsync: Run HTTP Server (Kestrel Http)

    1) Create IHostBuilder
    2) Cấu hình , call service
    3) Build => app
    4) app run

    Request =>pipeline(middleware)
*/