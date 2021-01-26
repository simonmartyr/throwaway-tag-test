using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace TagTest.Database
{
  public static class HostExtensions
  {
    public static IWebHost MigrateDbContext<TContext>(this IWebHost Host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {

      using (var scope = Host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var context = services.GetService<TContext>();

        try
        {
          logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

          var retry = Policy.Handle<SqlException>().WaitAndRetry(new[]
            {
              TimeSpan.FromSeconds(3),
              TimeSpan.FromSeconds(5),
              TimeSpan.FromSeconds(8),
              TimeSpan.FromSeconds(13)
            });

          retry.Execute(() =>
          {
            context.Database.Migrate();
            seeder(context, services);
          });
          logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
        }
        catch (Exception ex)
        {
          logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
        }
      }

      return Host;
    }
  }
}
