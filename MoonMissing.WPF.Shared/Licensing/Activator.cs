#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing.WPF.Shared
// File Name: Activator.cs
// 
// Current Data:
// 2022-01-26 11:11 AM
// 
// Creation Date:
// 2022-01-26 9:59 AM

#endregion

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