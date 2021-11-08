using kmgiasoc.Countries.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace kmgiasoc.Cities.Dtos
{
    [Serializable]
    public class CityDto : FullAuditedEntityDto<int>
    {
        public int CountryId { get; set; }

        public CountryDto Country { get; set; }

        public string Name { get; set; }

        public int OrderCity { get; set; }

    }
}