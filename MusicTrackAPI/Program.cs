using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MusicTrackAPI.Data;

namespace MusicTrackAPI;

public class Program
{
    public static async Task Main(string[] args)
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

      
            var dbContext = host.Services.GetRequiredService<MusicTrackAPIDbContext>();

            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Count() > 0)
            {
               await dbContext.Database.MigrateAsync();
            }
            
        host.Run();
    }
}