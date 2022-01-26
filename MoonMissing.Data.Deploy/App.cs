using AllOverIt.Assertion;
using AllOverIt.GenericHost;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

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

        private Task CreateDataIfRequired()
        {
            return Task.CompletedTask;
        }
    }
}