#region Title Header

// Solution: MoonMissing
// Project: MoonMissing.Data.Assistant
// File Name: Program.cs
// 
// Current Data:
// 2022-01-30 10:37 AM
// 
// Creation Date:
// 2022-01-30 10:32 AM

#endregion

#region usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AllOverIt.Assertion;
using AllOverIt.Extensions;
using CsvHelper;
using MoonMissing.Data.Assistant.Models;
using Newtonsoft.Json;

#endregion

namespace MoonMissing.Data.Assistant
{
  internal static class Program
  {
    public static void Main()
    {
      var data = UpdateJson();
      File.WriteAllText("newJson.json", JsonConvert.SerializeObject(data, Formatting.Indented));

      Console.WriteLine(Environment.NewLine + "Done");

      Console.ReadKey(true);
    }

    /// <summary>
    ///   Updates the JSON file to include the added contents of the CSV file used during community development
    /// </summary>
    private static IEnumerable<MoonData> UpdateJson()
    {
      var fileData = Encoding.Default.GetString(Resources.Resources.MoonData);
      var data = JsonConvert.DeserializeObject<List<MoonData>>(fileData)
        .WhenNotNullOrEmpty(nameof(fileData))
        .AsList();

      using var reader = new StringReader(Resources.Resources.newdata);
      using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      var newData = csvReader.GetRecords<CsvData>();

      var imgNames = GetMoonImageNames().AsList();

      foreach (var csvData in newData)
      {
        foreach (var moonData in data)
        {
          if (csvData.Id == moonData.MoonId)
          {
            moonData.ImageNames = new List<string>();

            var imgs = imgNames.Where(x => x.Item1 == moonData.MoonId).AsList();
            if (imgs.Any())
            {
              moonData.ImageNames.AddRange(imgs.Select(x => $"{x.Item1}_{x.Item2}"));
            }

            moonData.Description = csvData.Description;
            break;
          }
        }
      }

      return data.AsReadOnlyList();
    }

    private static IEnumerable<(int, int)> GetMoonImageNames()
    {
      return Directory.GetFiles(@"../../../../Assets/Moon Locations", "*.png")
        .Select(x => Path.GetFileNameWithoutExtension(x).Split('_'))
        .Select(x => (int.Parse(x[0]), int.Parse(x[1])))
        .AsList();
    }
  }
}