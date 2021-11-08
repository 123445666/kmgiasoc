using kmgiasoc.Countries.Dtos;
using System;
using System.ComponentModel;
namespace kmgiasoc.Cities.Dtos
{
    [Serializable]
    public class CityCreateDto
    {
        public int CountryId { get; set; }

        public CountryDto Country { get; set; }

        public string Name { get; set; }

        public int OrderCity { get; set; }

    }
}