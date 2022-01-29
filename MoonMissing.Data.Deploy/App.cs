#region usings

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllOverIt.Assertion;
using AllOverIt.Extensions;
using AllOverIt.GenericHost;
using AllOverIt.Serialization.Abstractions;
using AllOverIt.Serialization.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using MoonMissing.Data.Deploy.Models;
using MoonMissing.Data.Entities;

#endregion

namespace MoonMissing.Data.Deploy
{
  internal sealed class App : ConsoleAppBase
  {
    private readonly MoonMissingDeployDbContext _dbContext;

    public App(MoonMissingDeployDbContext dbContext)
    {
      _dbContext = dbContext.WhenNotNull(nameof(dbContext));
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
      // Just while testing
      //await _dbContext.Database.EnsureDeletedAsync(cancellationToken);

      await _dbContext.Database.MigrateAsync(cancellationToken);

      await CreateDataIfRequired();
    }

    private async Task CreateDataIfRequired()
    {
      var haveData = await _dbContext.Kingdoms
        .AnyAsync()
        .ConfigureAwait(false);

      if (!haveData)
      {
        var moonData = await LoadJsonMoonData().ConfigureAwait(false);

        var groupedMoonData = moonData
          .GroupBy(item => new
          {
            item.KingdomId,
            item.KingdomName
          })
          .AsReadOnlyCollection();

        foreach (var kingdom in groupedMoonData)
        {
          var kingdomEntity = new Kingdom
          {
            Id = kingdom.Key.KingdomId,
            Name = kingdom.Key.KingdomName,
            Moons = kingdom
              .Select(item => new Moon
              {
                Id = item.MoonId,
                Number = item.MoonNumber
              })
              .ToList()
          };

          _dbContext.Kingdoms.Add(kingdomEntity);
        }

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
      }
    }

    private static IJsonSerializer GetSerializer()
    {
      var serializer = new NewtonsoftJsonSerializer();

      var serializerConfig = new JsonSerializerConfiguration
      {
        SupportEnrichedEnums = true
      };

      serializer.Configure(serializerConfig);

      return serializer;
    }

    private static async Task<IReadOnlyCollection<MoonData>> LoadJsonMoonData()
    {
      using (var fileStream = File.OpenRead("MoonData.json"))
      {
        var serializer = GetSerializer();

        return await serializer
          .DeserializeObjectAsync<IReadOnlyCollection<MoonData>>(fileStream, CancellationToken.None)
          .ConfigureAwait(false);
      }
    }
  }
}