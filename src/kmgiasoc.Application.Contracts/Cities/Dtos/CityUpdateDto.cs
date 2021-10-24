using System;
using System.ComponentModel;

namespace kmgiasoc.Cities.Dtos
{
    [Serializable]
    public class CityUpdateDto
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public int OrderCity { get; set; }
    }
}