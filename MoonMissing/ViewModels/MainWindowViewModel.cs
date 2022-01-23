#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: MainWindowViewModel.cs
// 
// Current Data:
// 2022-01-23 7:00 PM
// 
// Creation Date:
// 2022-01-23 6:58 PM

#endregion

#region usings

using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using AllOverIt.Extensions;
using MoonMissing.Models;

#endregion

namespace MoonMissing.ViewModels
{
  internal class MainWindowViewModel
  {
    private readonly IReadOnlyList<MoonInfoWindowViewModel> _moonWindowViewModels;
    public BitmapImage Image { get; set; }

    public MainWindowViewModel(IEnumerable<MoonData> moonData)
    {
      _moonWindowViewModels = moonData
        .OrderBy(x => x.Kingdom.Value)
        .ThenBy(x => x.MoonNumber)
        .GroupBy(x => x.Kingdom.Name)
        .Select(x => new MoonInfoWindowViewModel(x))
        .AsReadOnlyList();
    }
  }
}