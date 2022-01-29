
#region usings

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Syncfusion.Licensing;

#endregion

namespace MoonMissing.WPF.Shared.Licensing
{
  public static class Activator
  {
    private static readonly IConfigurationRoot Configuration;

    static Activator()
    {
      Configuration = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetCallingAssembly())
        .Build();
    }

    public static void ActivateSyncFusion()
    {
      SyncfusionLicenseProvider.RegisterLicense(Configuration["Licenses:SyncfusionLicenseKey"]);
    }
  }
}