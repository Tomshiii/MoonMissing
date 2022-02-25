#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using MoonMissing.Data.Models;
using MoonMissing.Data.Repositories;

#endregion

namespace MoonMissing.ViewModels
{
  public class MainWindowViewModel
  {
    private readonly IMoonMissingRepository _repository;

    public MainWindowViewModel(IMoonMissingRepository repository)
    {
      _repository = repository;

      var kingdoms = GetKingdomsAsync().Result;
    }

    private async Task<IReadOnlyCollection<KingdomName>> GetKingdomsAsync()
    {
      return await _repository.GetKingdomNamesAsync().ConfigureAwait(false);
    }
  }
}