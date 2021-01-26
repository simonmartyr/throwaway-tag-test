using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TagTest.Database;

namespace TagTest
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateWebHost(args);
      host.MigrateDbContext<TagContext>((_, __) => { });
      host.Run();
    }

    public static IWebHost CreateWebHost(string[] args)
    {
      return WebHost
      .CreateDefaultBuilder(args)
      .UseStartup<Startup>()
      .Build();
    }

  }
}
