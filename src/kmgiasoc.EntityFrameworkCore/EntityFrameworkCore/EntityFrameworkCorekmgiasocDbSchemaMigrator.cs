using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using kmgiasoc.Data;
using Volo.Abp.DependencyInjection;

namespace kmgiasoc.EntityFrameworkCore
{
    public class EntityFrameworkCorekmgiasocDbSchemaMigrator
        : IkmgiasocDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorekmgiasocDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the kmgiasocDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<kmgiasocDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
