using AllOverIt.GenericHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoonMissing.Data.Deploy;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await GenericHost
            .CreateConsoleHostBuilder()
            .ConfigureServices(services =>
            {
                services.AddDbContextFactory<MoonMissingDeployDbContext>();
                services.AddSingleton<IConsoleApp, App>();
            })
            .RunConsoleAsync(options => options.SuppressStatusMessages = true);
    }
}