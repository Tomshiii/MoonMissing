#region usings

using System.Threading.Tasks;
using AllOverIt.GenericHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoonMissing.Data.Deploy;
using MoonMissing.Data.Extensions;

#endregion

internal class Program
{
  // To re-create the Migrations use powershell:
  // add-migration -Context MoonMissingDeployDbContext
  private static async Task Main()
  {
    await GenericHost
      .CreateConsoleHostBuilder()
      .ConfigureServices(services =>
      {
        // Only required by this deployment app
        services.AddDbContextFactory<MoonMissingDeployDbContext>();
        services.AddSingleton<IConsoleApp, App>();

        // Also adds IDbContextFactory<MoonMissingDbContext>
        services.AddRepository();
      })
      .RunConsoleAsync(options => options.SuppressStatusMessages = true);
  }
}