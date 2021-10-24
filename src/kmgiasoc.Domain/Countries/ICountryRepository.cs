using System;
using Volo.Abp.Domain.Repositories;

namespace kmgiasoc.Countries
{
    public interface ICountryRepository : IRepository<Country, int>
    {
    }
}