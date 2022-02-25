﻿#region usings

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