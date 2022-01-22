#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: MainWindowViewModel.cs
// 
// Current Data:
// 2022-01-22 7:55 PM
// 
// Creation Date:
// 2022-01-22 4:13 PM

#endregion

#region usings

using System.Collections.Generic;
using System.Linq;
using AllOverIt.Extensions;
using MoonMissing.Models;

#endregion

namespace MoonMissing.ViewModels
{
  internal class MainWindowViewModel
  {
    private readonly IReadOnlyList<MoonInfoWindowViewModel> _moonWindowViewModels;

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