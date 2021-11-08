using System;
using System.ComponentModel;

namespace kmgiasoc.Countries.Dtos
{
    [Serializable]
    public class CountryUpdateDto
    {
        public string Name { get; set; }

        public string Flag { get; set; }

        public int OrderCountry { get; set; }

    }
}