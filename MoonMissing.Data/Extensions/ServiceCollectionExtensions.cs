#region usings

using Microsoft.Extensions.DependencyInjection;
using MoonMissing.Data.Repositories;

#endregion

namespace MoonMissing.Data.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static void AddRepository(this IServiceCollection services)
    {
      services.AddDbContextFactory<MoonMissingDbContext>();
      services.AddSingleton<IMoonMissingRepository, MoonMissingRepository>();
    }
  }
}