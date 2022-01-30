using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllOverIt.Assertion;
using Microsoft.EntityFrameworkCore;
using MoonMissing.Data.Models;

namespace MoonMissing.Data.Repositories
{
    internal sealed class MoonMissingRepository : IMoonMissingRepository
    {
        private readonly IDbContextFactory<MoonMissingDbContext> _dbContextFactory;

        public MoonMissingRepository(IDbContextFactory<MoonMissingDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory.WhenNotNull(nameof(dbContextFactory));
        }

        public async Task<IReadOnlyCollection<KingdomName>> GetKingdomNamesAsync(CancellationToken cancellationToken = default)
        {
            await using (var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var query = from kingdom in dbContext.Kingdoms
                    select kingdom.Name;

                return await query.ToListAsync(cancellationToken);
            }
        }
    }
}