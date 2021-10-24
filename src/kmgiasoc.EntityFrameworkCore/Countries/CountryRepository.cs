using System;
using kmgiasoc.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace kmgiasoc.Countries
{
    public class CountryRepository : EfCoreRepository<kmgiasocDbContext, Country, int>, ICountryRepository
    {
        public CountryRepository(IDbContextProvider<kmgiasocDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}