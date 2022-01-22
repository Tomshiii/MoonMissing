#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: MainWindowViewModel.cs
// 
// Current Data:
// 2022-01-22 8:34 PM
// 
// Creation Date:
// 2022-01-22 4:13 PM

#endregion

#region usings

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Imaging;
using AllOverIt.Extensions;
using MoonMissing.Extensions;
using MoonMissing.Models;
using MoonMissing.Resources;

#endregion

namespace MoonMissing.ViewModels
{
  public class ImageFactory
  {
    private readonly ImageConverter _imageConverter = new();
    private readonly IReadOnlyDictionary<int, Func<Bitmap>> _registry;

    public ImageFactory()
    {
      _registry = new Dictionary<int, Func<Bitmap>>
      {
        [0] = () => (Bitmap)_imageConverter.ConvertFrom(LevelImages.Cap)
      };
    }

    public BitmapImage Create(int key)
    {
      if (_registry.TryGetValue(key, out var value))
      {
        if (value is null)
        {
          throw new InvalidOperationException();
        }

        var image = value();

        if (image is null)
        {
          throw new InvalidOperationException();
        }

        return image.ToBitmapImage();
      }

      throw new InvalidOperationException("Key is not registered");
    }
  }

  internal class MainWindowViewModel
  {
    private readonly ImageFactory _imageFactory = new();
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

      Image = _imageFactory.Create(0);
    }
  }
}