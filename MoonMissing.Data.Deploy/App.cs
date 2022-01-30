using AllOverIt.Assertion;
using AllOverIt.Extensions;
using AllOverIt.GenericHost;
using AllOverIt.Serialization.Abstractions;
using AllOverIt.Serialization.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using MoonMissing.Data.Deploy.Models;
using MoonMissing.Data.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoonMissing.Data.Deploy
{
    internal sealed class App : ConsoleAppBase
    {
        private readonly IDbContextFactory<MoonMissingDeployDbContext> _dbContextFactory;

        public App(IDbContextFactory<MoonMissingDeployDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory.WhenNotNull(nameof(dbContextFactory));
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await using (var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                // Just while testing
                //await dbContext.Database.EnsureDeletedAsync(cancellationToken);

                await dbContext.Database.MigrateAsync(cancellationToken);

                await CreateDataIfRequired(dbContext, cancellationToken);
            }
        }

        private static async Task CreateDataIfRequired(MoonMissingDeployDbContext dbContext, CancellationToken cancellationToken)
        {
            var haveData = await dbContext.Kingdoms
                .AnyAsync(cancellationToken)
                .ConfigureAwait(false);

            if (!haveData)
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

                    dbContext.Kingdoms.Add(kingdomEntity);
                }

                await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
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
            await using (var fileStream = File.OpenRead("MoonData.json"))
            {
                var serializer = GetSerializer();

                return await serializer
                    .DeserializeObjectAsync<IReadOnlyCollection<MoonData>>(fileStream, cancellationToken)
                    .ConfigureAwait(false);
            }
        }
    }
}