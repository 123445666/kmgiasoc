using System;
using Volo.Abp.Domain.Repositories;

namespace kmgiasoc.DealCategories
{
    public interface IDealCategoryRepository : IRepository<DealCategory, Guid>
    {
    }
}