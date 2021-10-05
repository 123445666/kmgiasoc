using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace kmgiasoc.DealCategories
{
    public static class DealCategoryEfCoreQueryableExtensions
    {
        public static IQueryable<DealCategory> IncludeDetails(this IQueryable<DealCategory> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}