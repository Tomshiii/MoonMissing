#region usings

using System.Windows;
using MoonMissing.ViewModels;

#endregion

namespace MoonMissing.Views
{
  /// <summary>
  ///   Interaction logic for MainWindowView.xaml
  /// </summary>
  public partial class MainWindowView : Window
  {
    public MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext;

    public MainWindowView(MainWindowViewModel vm)
    {
      DataContext = vm;

      InitializeComponent();
    }
  }
}