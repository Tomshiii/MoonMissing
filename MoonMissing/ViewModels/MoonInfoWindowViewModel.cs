using System.Collections.Generic;
using MoonMissing.Models;

namespace MoonMissing.ViewModels
{
  internal class MoonInfoWindowViewModel
  {
    private IEnumerable<MoonData> _moonData;

    public MoonInfoWindowViewModel(IEnumerable<MoonData> moonData)
    {
      _moonData = moonData;
    }
  }
}