using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllOverIt.Assertion;
using AllOverIt.Extensions;
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

        public async Task<IReadOnlyCollection<IMoonDetail>> GetMoonDetailsAsync(int kingdomId, CancellationToken cancellationToken = default)
        {
            await using (var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var query = from moon in dbContext.Moons
                            where moon.Kingdom.Id == kingdomId
                            select new MoonDetail
                            {
                                Id = moon.Id,
                                Name = moon.MoonName,
                                Number = moon.Number,
                                Quadrant = moon.Quadrant,
                                IsMultiMoon = moon.IsMultiMoon,
                                IsRockMoon = moon.IsRockMoon,
                                IsSubAreaMoon = moon.IsSubAreaMoon,
                            };

                return await query.ToListAsync(cancellationToken);

                //return results.SelectAsReadOnlyCollection(item => new MoonDetail
                //{
                //    Id = item.Id,
                //    Name = item.MoonName,
                //    Number = item.Number,
                //    Quadrant = item.Quadrant,
                //    IsMultiMoon = item.IsMultiMoon,
                //    IsRockMoon = item.IsRockMoon,
                //    IsSubAreaMoon = item.IsSubAreaMoon,
                //});
            }
        }
    }
}