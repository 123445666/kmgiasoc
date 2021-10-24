using System;
using Volo.Abp.Application.Dtos;

namespace kmgiasoc.Cities.Dtos
{
    [Serializable]
    public class CityDto : AuditedEntityDto<int>
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public int OrderCity { get; set; }
    }
}