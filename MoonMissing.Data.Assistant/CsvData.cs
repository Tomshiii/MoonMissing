namespace MoonMissing.Data.Assistant;

public record CsvData
{
  public int Id { get; set; }
  public int MoonNumber { get; set; }
  public string Kingdom { get; set; }
  public string Description { get; set; }
}