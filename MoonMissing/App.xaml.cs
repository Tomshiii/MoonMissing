#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: App.xaml.cs
// 
// Current Data:
// 2022-01-22 4:11 PM
// 
// Creation Date:
// 2022-01-22 4:01 PM

#endregion

#region usings

using System.Windows;

#endregion

namespace MoonMissing
{
  /// <summary>
  ///   Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      ApplicationShell.NewAppShell();
    }
  }
}