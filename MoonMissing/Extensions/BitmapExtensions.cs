#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: BitmapExtensions.cs
// 
// Current Data:
// 2022-01-22 8:39 PM
// 
// Creation Date:
// 2022-01-22 8:38 PM

#endregion

#region usings

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

#endregion

namespace MoonMissing.Extensions
{
  internal static class BitmapExtensions
  {
    public static BitmapImage ToBitmapImage(this Bitmap bitmap)
    {
      using var memory = new MemoryStream();

      bitmap.Save(memory, ImageFormat.Png);
      memory.Position = 0;

      var bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.StreamSource = memory;
      bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
      bitmapImage.EndInit();
      bitmapImage.Freeze();

      return bitmapImage;
    }
  }
}