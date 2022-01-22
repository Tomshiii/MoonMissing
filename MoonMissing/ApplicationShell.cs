#region Title Header

// Name: Phillip Smith
// 
// Solution: MoonMissing
// Project: MoonMissing
// File Name: ApplicationShell.cs
// 
// Current Data:
// 2022-01-22 7:59 PM
// 
// Creation Date:
// 2022-01-22 4:08 PM

#endregion

#region usings

#endregion

#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MoonMissing.Models;
using MoonMissing.Resources;
using MoonMissing.ViewModels;
using MoonMissing.Views;
using Newtonsoft.Json;

#endregion

namespace MoonMissing
{
  internal class ApplicationShell
  {
    private ApplicationShell()
    {
      var moonData = GetMoonData();
      //WriteAsCsv(moonData);

      var window = new MainWindowView
      {
        DataContext = new MainWindowViewModel(moonData)
      };
      window.ShowDialog();

      Environment.Exit(0);
    }

    public static ApplicationShell NewAppShell()
    {
      return new ApplicationShell();
    }

    private static IEnumerable<MoonData> GetMoonData()
    {
      // NOTE: Check moon.json needs to be EmbeddedResource.

      var fileData = Encoding.Default.GetString(EmbeddedData.MoonData);
      var moonData = JsonConvert.DeserializeObject<List<MoonData>>(fileData);

      return moonData ?? throw new NullReferenceException("Moon Data did not deserialize");
    }

    private static void WriteAsCsv(IEnumerable<MoonData> moonData)
    {
      var csv = new StringBuilder();

      csv.AppendLine("id,moonNumber,kingdom,moonName,,");
      foreach (var data in moonData)
      {
        csv.AppendLine($"{data.Id},{data.MoonNumber},{data.Kingdom.Name},{data.MoonName.Replace(",", "")},,");
      }

      File.WriteAllText("CSV_MOONS.csv", csv.ToString());
    }
  }
}