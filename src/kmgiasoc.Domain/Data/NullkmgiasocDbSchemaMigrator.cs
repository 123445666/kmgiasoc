using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace kmgiasoc.Data
{
    /* This is used if database provider does't define
     * IkmgiasocDbSchemaMigrator implementation.
     */
    public class NullkmgiasocDbSchemaMigrator : IkmgiasocDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}