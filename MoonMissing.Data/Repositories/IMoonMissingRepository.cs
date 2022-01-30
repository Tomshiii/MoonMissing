using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MoonMissing.Data.Models;

namespace MoonMissing.Data.Repositories
{
    public interface IMoonMissingRepository
    {
        Task<IReadOnlyCollection<KingdomName>> GetKingdomNamesAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<IMoonDetail>> GetMoonDetailsAsync(int kingdomId, CancellationToken cancellationToken = default);
    }
}