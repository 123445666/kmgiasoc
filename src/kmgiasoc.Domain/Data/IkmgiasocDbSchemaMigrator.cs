using System.Threading.Tasks;

namespace kmgiasoc.Data
{
    public interface IkmgiasocDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
