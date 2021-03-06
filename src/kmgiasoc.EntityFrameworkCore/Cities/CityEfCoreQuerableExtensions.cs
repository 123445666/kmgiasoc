using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace kmgiasoc.Cities
{
    public static class CityEfCoreQueryableExtensions
    {
        public static IQueryable<City> IncludeDetails(this IQueryable<City> queryable, bool include = true)
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