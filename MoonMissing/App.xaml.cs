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
      ApplicationShell.RunApplication();
    }
  }
}