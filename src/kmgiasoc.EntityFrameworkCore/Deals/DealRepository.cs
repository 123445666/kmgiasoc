using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using kmgiasoc.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.CmsKit.Users;

namespace kmgiasoc.Deals
{
    public class DealRepository : EfCoreRepository<kmgiasocDbContext, Deal, Guid>, IDealRepository
    {
        public DealRepository(IDbContextProvider<kmgiasocDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Deal> GetBySlugAsync(
            Guid dealCategoryId,
            [NotNull] string slug,
            CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(slug, nameof(slug));

            var deal = await GetAsync(
                                    x => x.DealCategoryId == dealCategoryId && x.Slug.ToLower() == slug,
                                    cancellationToken: GetCancellationToken(cancellationToken));

            deal.Author = await (await GetDbContextAsync())
                                .Set<CmsUser>()
                                .FirstOrDefaultAsync(x => x.Id == deal.AuthorId, GetCancellationToken(cancellationToken));

            return deal;
        }

        public virtual async Task<int> GetCountAsync(
            string filter = null,
            Guid? dealCategoryId = null,
            CancellationToken cancellationToken = default)
        {
            var queryable = (await GetDbSetAsync())
               .WhereIf(dealCategoryId.HasValue, x => x.DealCategoryId == dealCategoryId)
               .WhereIf(!string.IsNullOrEmpty(filter), x => x.Title.Contains(filter) || x.Slug.Contains(filter));

            var count = await queryable.CountAsync(GetCancellationToken(cancellationToken));
            return count;
        }

        public virtual async Task<List<Deal>> GetListAsync(
            string filter = null,
            Guid? dealCategoryId = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default)

        {
            var dbContext = await GetDbContextAsync();
            var dealsDbSet = dbContext.Set<Deal>();
            var usersDbSet = dbContext.Set<CmsUser>();

            var queryable = dealsDbSet
                .WhereIf(dealCategoryId.HasValue, x => x.DealCategoryId == dealCategoryId)
                .WhereIf(!string.IsNullOrWhiteSpace(filter), x => x.Title.Contains(filter) || x.Slug.Contains(filter));

            queryable = queryable.OrderBy(sorting.IsNullOrEmpty() ? $"{nameof(Deal.CreationTime)} desc" : sorting);

            var combinedResult = await queryable
                .Join(
                    usersDbSet,
                    o => o.AuthorId,
                    i => i.Id,
                    (deal, user) => new { deal, user })
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return combinedResult.Select(s =>
            {
                s.deal.Author = s.user;
                return s.deal;
            }).ToList();
        }

        public virtual async Task<List<Deal>> GetListByPriorityAsync(
           string filter = null,
           int? dealPriority = null,
           Guid? dealCategoryId = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           string sorting = null,
           CancellationToken cancellationToken = default)

        {
            var dbContext = await GetDbContextAsync();
            var dealsDbSet = dbContext.Set<Deal>();
            var usersDbSet = dbContext.Set<CmsUser>();

            var queryable = dealsDbSet
                .WhereIf(dealCategoryId.HasValue, x => x.DealCategoryId == dealCategoryId)
                .WhereIf(dealPriority.HasValue, x => x.DealPriority == dealPriority)
                .WhereIf(!string.IsNullOrWhiteSpace(filter), x => x.Title.Contains(filter) || x.Slug.Contains(filter));

            queryable = queryable.OrderBy(sorting.IsNullOrEmpty() ? $"{nameof(Deal.CreationTime)} desc" : sorting);

            var combinedResult = await queryable
                .Join(
                    usersDbSet,
                    o => o.AuthorId,
                    i => i.Id,
                    (deal, user) => new { deal, user })
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return combinedResult.Select(s =>
            {
                s.deal.Author = s.user;
                return s.deal;
            }).ToList();
        }

        public async Task<bool> SlugExistsAsync(Guid dealCategoryId, [NotNull] string slug,
            CancellationToken cancellationToken = default)
        {
            Check.NotNullOrEmpty(slug, nameof(slug));

            return await (await GetDbSetAsync()).AnyAsync(x => x.DealCategoryId == dealCategoryId && x.Slug.ToLower() == slug,
                GetCancellationToken(cancellationToken));
        }
    }
}