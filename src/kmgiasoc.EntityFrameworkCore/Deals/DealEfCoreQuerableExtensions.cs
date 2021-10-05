using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace kmgiasoc.Deals
{
    public static class DealEfCoreQueryableExtensions
    {
        public static IQueryable<Deal> IncludeDetails(this IQueryable<Deal> queryable, bool include = true)
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