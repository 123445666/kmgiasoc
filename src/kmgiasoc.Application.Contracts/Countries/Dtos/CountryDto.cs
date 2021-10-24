using System;
using Volo.Abp.Application.Dtos;

namespace kmgiasoc.Countries.Dtos
{
    [Serializable]
    public class CountryDto : AuditedEntityDto<int>
    {
        public string Name { get; set; }

        public string Flag { get; set; }

        public int OrderCountry { get; set; }
    }
}