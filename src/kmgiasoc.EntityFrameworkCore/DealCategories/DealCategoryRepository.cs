using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using kmgiasoc.Deals;
using kmgiasoc.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.CmsKit.Users;

namespace kmgiasoc.DealCategories
{
    public class DealCategoryRepository : EfCoreRepository<kmgiasocDbContext, DealCategory, Guid>, IDealCategoryRepository
    {
        public DealCategoryRepository(IDbContextProvider<kmgiasocDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).AnyAsync(x => x.Id == id, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).AnyAsync(x => x.Slug == slug, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<DealCategory>> GetListAsync(
            string filter = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetListQueryAsync(filter);

            return await query.OrderBy(sorting.IsNullOrEmpty() ? "creationTime desc" : sorting)
                              .PageBy(skipCount, maxResultCount)
                              .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            var query = await GetListQueryAsync(filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public virtual Task<DealCategory> GetBySlugAsync([NotNull] string slug, CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(slug, nameof(slug));
            return GetAsync(x => x.Slug == slug, cancellationToken: GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<DealCategory>> GetListQueryAsync(string filter = null)
        {
            return (await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(), b => b.Name.Contains(filter));
        }
    }
}