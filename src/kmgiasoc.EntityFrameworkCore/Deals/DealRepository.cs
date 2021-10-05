using System;
using kmgiasoc.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace kmgiasoc.Deals
{
    public class DealRepository : EfCoreRepository<kmgiasocDbContext, Deal, Guid>, IDealRepository
    {
        public DealRepository(IDbContextProvider<kmgiasocDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}