using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace kmgiasoc.Countries
{
    public class Country : AuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public int OrderCountry { get; set; }

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
    }
}
