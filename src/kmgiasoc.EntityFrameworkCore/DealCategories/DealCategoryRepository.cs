using System;
using kmgiasoc.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace kmgiasoc.DealCategories
{
    public class DealCategoryRepository : EfCoreRepository<kmgiasocDbContext, DealCategory, Guid>, IDealCategoryRepository
    {
        public DealCategoryRepository(IDbContextProvider<kmgiasocDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}