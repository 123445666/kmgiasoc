using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace kmgiasoc.Cities
{
    public class City : AuditedAggregateRoot<int>
    {
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int OrderCity { get; set; }


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
    }
}
