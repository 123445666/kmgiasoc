using System;
using kmgiasoc.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace kmgiasoc.Cities
{
    public class CityRepository : EfCoreRepository<kmgiasocDbContext, City, int>, ICityRepository
    {
        public CityRepository(IDbContextProvider<kmgiasocDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}