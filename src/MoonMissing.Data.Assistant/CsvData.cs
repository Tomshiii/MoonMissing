#region Title Header

// Solution: MoonMissing
// Project: MoonMissing.Data.Assistant
// File Name: CsvData.cs
// 
// Current Data:
// 2022-01-30 10:37 AM
// 
// Creation Date:
// 2022-01-30 10:32 AM

#endregion

namespace MoonMissing.Data.Assistant;

public record CsvData
{
  public int Id { get; set; }
  public int MoonNumber { get; set; }
  public string Kingdom { get; set; }
  public string Description { get; set; }
}