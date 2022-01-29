#region usings

using System.Threading.Tasks;
using AllOverIt.GenericHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoonMissing.Data.Deploy;

#endregion

internal class Program
{
  private static async Task Main()
  {
    await GenericHost
      .CreateConsoleHostBuilder()
      .ConfigureServices(services =>
      {
        services.AddDbContext<MoonMissingDeployDbContext>();
        services.AddScoped<IConsoleApp, App>();
      })
      .RunConsoleAsync(options => options.SuppressStatusMessages = true);
  }
}