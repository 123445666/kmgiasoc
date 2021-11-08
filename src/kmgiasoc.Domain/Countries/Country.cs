using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace kmgiasoc.Countries
{
    public class Country : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public int OrderCountry { get; set; }
        public Guid? TenantId { get; protected set; }

        protected Country()
        {
        }

        public Country(
            int id,
            string name,
            string flag,
            int orderCountry
        ) : base(id)
        {
            Name = name;
            Flag = flag;
            OrderCountry = orderCountry;
        }

        public Country(
            int id,
            string name,
            string flag,
            int orderCountry,
            Guid? tenantId
        ) : base(id)
        {
            Name = name;
            Flag = flag;
            OrderCountry = orderCountry;
            TenantId = tenantId;
        }
    }
}
