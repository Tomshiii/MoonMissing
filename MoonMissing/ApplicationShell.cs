#region usings

using System;
using Microsoft.Extensions.DependencyInjection;
using MoonMissing.Data.Extensions;
using MoonMissing.ViewModels;
using MoonMissing.Views;
using Activator = MoonMissing.WPF.Shared.Licensing.Activator;

#endregion

namespace MoonMissing
{
  internal class ApplicationShell
  {
    private ApplicationShell()
    {
      Activator.ActivateSyncFusion();

      var servicesCollection = new ServiceCollection();
      ConfigureServices(servicesCollection);
      var provider = servicesCollection.BuildServiceProvider();

      LaunchMainWindow(provider);

      Environment.Exit(0);
    }

    private static void ConfigureServices(IServiceCollection servicesCollection)
    {
      servicesCollection.AddRepository(); // Adds dbContext and repository
      servicesCollection.AddSingleton<MainWindowViewModel>();
      servicesCollection.AddSingleton<MainWindowView>();
      servicesCollection.AddSingleton<KingdomInfoWindowViewModel>();
      servicesCollection.AddSingleton<KingdomMoonsWindowView>();
    }

    private static void LaunchMainWindow(IServiceProvider serviceProvider)
    {
      var window = serviceProvider.GetRequiredService<MainWindowView>();
      window.ShowDialog();
    }

    public static ApplicationShell RunApplication()
    {
      return new ApplicationShell();
    }
  }
}