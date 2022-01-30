#region usings

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllOverIt.Assertion;
using AllOverIt.Extensions;
using Microsoft.EntityFrameworkCore;
using MoonMissing.Data.Models;

#endregion

namespace MoonMissing.Data.Repositories
{
  internal sealed class MoonMissingRepository : IMoonMissingRepository
  {
    private readonly IDbContextFactory<MoonMissingDbContext> _dbContextFactory;

    public async Task<IReadOnlyCollection<KingdomName>> GetKingdomNamesAsync(
      CancellationToken cancellationToken = default)
    {
      await using (var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
      {
        var query = from kingdom in dbContext.Kingdoms
          select kingdom.Name;

        return await query.ToListAsync(cancellationToken);
      }
    }

    public async Task<IReadOnlyCollection<IMoonDetail>> GetMoonDetailsAsync(int kingdomId,
      CancellationToken cancellationToken = default)
    {
      await using (var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
      {
        var query =
          from moon in dbContext.Moons
          where moon.Kingdom.Id == kingdomId
          let images = from moonImage in moon.MoonImages
            select new
            {
              moonImage.Image.Id,
              moonImage.Image.Name
            }
          select new
          {
            Moon = moon,
            Images = images
          };

        var results = await query.ToListAsync(cancellationToken);

        return results.SelectAsReadOnlyCollection(item =>
        {
          return new MoonDetail
          {
            Id = item.Moon.Id,
            Name = item.Moon.MoonName,
            Number = item.Moon.Number,
            Quadrant = item.Moon.Quadrant,
            IsMultiMoon = item.Moon.IsMultiMoon,
            IsRockMoon = item.Moon.IsRockMoon,
            IsSubAreaMoon = item.Moon.IsSubAreaMoon,
            MoonImages = item.Images.SelectAsReadOnlyCollection(image => new MoonImage
            {
              Id = image.Id,
              Name = image.Name
            })
          };
        });
      }
    }

    public async Task<byte[]> GetImageDataAsync(int imageId, CancellationToken cancellationToken = default)
    {
      await using (var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
      {
        var query = from image in dbContext.Images
          where image.Id == imageId
          select image.Data;

        return await query.SingleOrDefaultAsync(cancellationToken);
      }
    }

    public MoonMissingRepository(IDbContextFactory<MoonMissingDbContext> dbContextFactory)
    {
      _dbContextFactory = dbContextFactory.WhenNotNull(nameof(dbContextFactory));
    }
  }
}