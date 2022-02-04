#region usings

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MoonMissing.Data.Models;

#endregion

namespace MoonMissing.Data.Repositories
{
  public interface IMoonMissingRepository
  {
    Task<IReadOnlyCollection<KingdomName>> GetKingdomNamesAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<IMoonDetail>> GetMoonDetailsAsync(int kingdomId,
      CancellationToken cancellationToken = default);

    Task<byte[]> GetImageDataAsync(int imageId, CancellationToken cancellationToken = default);
  }
}