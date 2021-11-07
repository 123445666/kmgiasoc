using System;

using System.ComponentModel.DataAnnotations;

namespace kmgiasoc.Web.Pages.Cities.City.ViewModels
{
    public class CreateCityViewModel
    {
        [Display(Name = "CityCountryId")]
        public int CountryId { get; set; }

        [Display(Name = "CityName")]
        public string Name { get; set; }

        [Display(Name = "CityOrderCity")]
        public int OrderCity { get; set; }
    }
}