#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllOverIt.Assertion;
using AllOverIt.Extensions;
using AllOverIt.GenericHost;
using AllOverIt.Io;
using AllOverIt.Serialization.Abstractions;
using AllOverIt.Serialization.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using MoonMissing.Data.Deploy.Models;
using MoonMissing.Data.Entities;
using MoonMissing.Data.Repositories;

#endregion

namespace MoonMissing.Data.Deploy
{
  internal sealed class App : ConsoleAppBase
  {
    private readonly IDbContextFactory<MoonMissingDeployDbContext> _dbContextFactory;
    private readonly IMoonMissingRepository _repository;

    public App(IDbContextFactory<MoonMissingDeployDbContext> dbContextFactory, IMoonMissingRepository repository)
    {
      _dbContextFactory = dbContextFactory.WhenNotNull(nameof(dbContextFactory));
      _repository = repository.WhenNotNull(nameof(repository));
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
      await using (var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
      {
        await dbContext.Database.EnsureDeletedAsync(cancellationToken);

        await dbContext.Database.MigrateAsync(cancellationToken);

        await CreateDataIfRequired(dbContext, cancellationToken);

        var kingdoms = await _repository.GetKingdomNamesAsync(cancellationToken);

        foreach (var kingdom in kingdoms)
        {
          Console.WriteLine($"{kingdom.Value} - {kingdom.Name}");
        }

        //// Testing reading moon details and images
        //var moonDetails = await _repository.GetMoonDetailsAsync(1, cancellationToken);

        //// get the images asynchronously
        //var images = await moonDetails
        //    .SelectMany(item => item.MoonImages)
        //    .SelectAsync(item => _repository.GetImageDataAsync(item.Id, cancellationToken), cancellationToken)
        //    .AsListAsync(cancellationToken);
      }
    }

    private static async Task CreateDataIfRequired(MoonMissingDeployDbContext dbContext,
      CancellationToken cancellationToken)
    {
      var haveData = await dbContext.Kingdoms
        .AnyAsync(cancellationToken)
        .ConfigureAwait(false);

      if (!haveData)
      {
        await AddMoonImagesAsync(dbContext, cancellationToken).ConfigureAwait(false);
        await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        await AddKingdomMoonDataAsync(dbContext, cancellationToken).ConfigureAwait(false);
        await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
      }
    }

    private static async Task AddKingdomMoonDataAsync(MoonMissingDeployDbContext dbContext,
      CancellationToken cancellationToken)
    {
      var moonData = await LoadJsonMoonData(cancellationToken).ConfigureAwait(false);

      var groupedMoonData = moonData
        .GroupBy(item => new
        {
          item.KingdomId,
          item.KingdomName
        })
        .AsReadOnlyCollection();

      foreach (var kingdom in groupedMoonData)
      {
        var kingdomEntity = new KingdomEntity
        {
          Id = kingdom.Key.KingdomId,
          Name = kingdom.Key.KingdomName,
          Moons = await kingdom
            .SelectAsync(async item =>
            {
              var moonEntity = new MoonEntity
              {
                Id = item.MoonId,
                Number = item.MoonNumber,
                MoonName = item.MoonName,
                IsRockMoon = item.IsRockMoon,
                IsSubAreaMoon = item.IsSubAreaMoon,
                IsMultiMoon = item.IsMultiMoon,
                Quadrant = item.Quadrant,
                MoonImages = new List<MoonImageEntity>()
              };

              if (item.ImageNames.Any())
              {
                var query = from image in dbContext.Images
                  where item.ImageNames.Contains(image.Name)
                  select image;

                var results = await query.ToListAsync(cancellationToken).ConfigureAwait(false);

                foreach (var result in results)
                {
                  var moonImageEntity = new MoonImageEntity
                  {
                    Image = result
                  };

                  moonEntity.MoonImages.Add(moonImageEntity);
                }
              }

              return moonEntity;
            }, cancellationToken)
            .AsListAsync(cancellationToken)
        };

        dbContext.Kingdoms.Add(kingdomEntity);
      }
    }

    private static async Task AddMoonImagesAsync(MoonMissingDeployDbContext dbContext,
      CancellationToken cancellationToken)
    {
      var imageFiles = FileSearch.GetFiles(@"..\..\..\..\Assets\Moon Locations", "*.png", DiskSearchOptions.None,
        cancellationToken);

      foreach (var imageFile in imageFiles)
      {
        var imageBytes = await GetImageAsBytes(imageFile.FullName).ConfigureAwait(false);

        var imageEntity = new ImageEntity
        {
          Name = Path.GetFileNameWithoutExtension(imageFile.Name),
          Data = imageBytes
        };

        dbContext.Images.Add(imageEntity);
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

    private static async Task<IReadOnlyCollection<MoonData>> LoadJsonMoonData(CancellationToken cancellationToken)
    {
      // Assumes running from the bin\{build type}
      await using (var fileStream = File.OpenRead(@"..\..\..\..\Assets\MoonData.json"))
      {
        var serializer = GetSerializer();

        return await serializer
          .DeserializeObjectAsync<IReadOnlyCollection<MoonData>>(fileStream, cancellationToken)
          .ConfigureAwait(false);
      }
    }

    private static async Task<byte[]> GetImageAsBytes(string filename)
    {
      using (var stream = File.Open(filename, FileMode.Open))
      {
        using (var ms = new MemoryStream())
        {
          await stream.CopyToAsync(ms).ConfigureAwait(false);
          return ms.ToArray();
        }
      }
    }
  }
}