using System;
using Volo.Abp.Domain.Repositories;

namespace kmgiasoc.Cities
{
    public interface ICityRepository : IRepository<City, int>
    {
    }
}