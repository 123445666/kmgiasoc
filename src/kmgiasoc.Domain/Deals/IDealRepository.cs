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
            bool isPublished = false,
            bool isFeatured = false,
            Guid? dealCategoryId = null,
            CancellationToken cancellationToken = default);

        Task<List<Deal>> GetListAsync(
            string filter = null,
            bool isPublished = false,
            bool isFeatured = false,
            Guid? dealCategoryId = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default);

        Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken = default);

        Task<Deal> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}