using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace kmgiasoc.DealCategories
{
    public interface IDealCategoryRepository : IRepository<DealCategory, Guid>
    {
        Task<List<DealCategory>> GetListAsync(
           string filter = null,
           string sorting = null,
           int maxResultCount = int.MaxValue,
           int skipCount = 0,
           CancellationToken cancellationToken = default
           );

        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default
            );

        Task<DealCategory> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken = default);
    }
}