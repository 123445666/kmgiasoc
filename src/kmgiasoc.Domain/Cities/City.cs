using kmgiasoc.Countries;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace kmgiasoc.Cities
{
    public class City : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public int OrderCity { get; set; }
        public Guid? TenantId { get; protected set; }

        protected City()
        {
        }

        public City(
            int id,
            int countryId,
            string name,
            int orderCity
        ) : base(id)
        {
            CountryId = countryId;
            Name = name;
            OrderCity = orderCity;
        }

        public City(
            int id,
            int countryId,
            Country country,
            string name,
            int orderCity,
            Guid? tenantId
        ) : base(id)
        {
            CountryId = countryId;
            Country = country;
            Name = name;
            OrderCity = orderCity;
            TenantId = tenantId;
        }
    }
}
