using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace kmgiasoc.Deals
{
    public interface IDealRepository : IRepository<Deal, Guid>
    {
        Task<int> GetCountAsync(
            string filter = null,
            Guid? dealCategoryId = null,
            CancellationToken cancellationToken = default);

        Task<List<Deal>> GetListAsync(
            string filter = null,
            Guid? dealCategoryId = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default);

        Task<List<Deal>> GetListByPriorityAsync(
            string filter = null,
            int? DealPriority = null,
            Guid? dealCategoryId = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default);

        Task<bool> SlugExistsAsync(Guid dealCategoryId, string slug, CancellationToken cancellationToken = default);

        Task<Deal> GetBySlugAsync(Guid dealCategoryId, string slug, CancellationToken cancellationToken = default);
    }
}