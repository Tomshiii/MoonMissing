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
using System.Text;
using CsvHelper;
using MoonMissing.Data.Assistant.Models;

#endregion

namespace MoonMissing.Data.Assistant
{
  internal static class Program
  {
    public static void Main()
    {
      var data = UpdateJson();

      foreach (var moonData in data)
      {
        Console.WriteLine($"{moonData.MoonId} -- {moonData.MoonName} -- {moonData.Description}");
      }

      Console.WriteLine(Environment.NewLine + "Done");

      Console.ReadKey(true);
    }

    /// <summary>
    ///   Updates the JSON file to include the added contents of the CSV file used during community development
    /// </summary>
    private static IEnumerable<MoonData> UpdateJson()
    {
      var fileData = Encoding.Default.GetString(Resources.Resources.MoonData);
      var data = JsonConvert.DeserializeObject<List<MoonData>>(fileData).AsList();

      using var reader = new StringReader(Resources.Resources.newdata);
      using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      var newData = csvReader.GetRecords<CsvData>();

      foreach (var csvData in newData)
      {
        foreach (var moonData in data)
        {
          if (csvData.Id == moonData.MoonId)
          {
            moonData.Description = csvData.Description;
            break;
          }
        }
      }

      return data.AsReadOnlyList();
    }
  }
}