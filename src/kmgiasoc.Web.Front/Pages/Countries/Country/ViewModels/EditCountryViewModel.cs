using System;

using System.ComponentModel.DataAnnotations;

namespace kmgiasoc.Web.Pages.Countries.Country.ViewModels
{
    public class EditCountryViewModel
    {
        [Display(Name = "CountryName")]
        public string Name { get; set; }

        [Display(Name = "CountryFlag")]
        public string Flag { get; set; }

        [Display(Name = "CountryOrderCountry")]
        public int OrderCountry { get; set; }
    }
}