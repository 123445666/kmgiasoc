using System;
using Volo.Abp.Domain.Repositories;

namespace kmgiasoc.Deals
{
    public interface IDealRepository : IRepository<Deal, Guid>
    {
    }
}