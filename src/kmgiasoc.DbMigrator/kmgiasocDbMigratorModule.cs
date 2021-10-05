using kmgiasoc.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace kmgiasoc.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(kmgiasocEntityFrameworkCoreModule),
        typeof(kmgiasocApplicationContractsModule)
        )]
    public class kmgiasocDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
