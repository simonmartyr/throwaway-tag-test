using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using TagTest.Database;

namespace TagTest
{
  public static class DatabaseStartup
  {
    public static IServiceCollection ConfigureViewDatabase(this IServiceCollection services, IConfiguration configuration)
    {
      return ConfigureViewDatabaseSqlServer(services, configuration);
    }

    private static IServiceCollection ConfigureViewDatabaseSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
      return services
        .AddDbContextPool<TagContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("TagContext"),
            sqlOptions => sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null)));
    }
  }

  // public class ViewContextFactory : IDesignTimeDbContextFactory<TagContext>
  // {
  //   public TagContext CreateDbContext(string[] args)
  //   {
  //     return new TagContext(new DbContextOptionsBuilder<TagContext>().UseSqlServer().Options);
  //   }
  // }
}