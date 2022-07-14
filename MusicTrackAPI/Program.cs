using Autofac.Extensions.DependencyInjection;
namespace MusicTrackAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseStartup<Startup>();
            })
            .Build();

        host.Run();
    }
}