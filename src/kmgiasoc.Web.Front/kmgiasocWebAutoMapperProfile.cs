using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Web.Pages.DealCategories.DealCategory.ViewModels;
using kmgiasoc.Deals.Dtos;
using kmgiasoc.Web.Pages.Deals.Deal.ViewModels;
using kmgiasoc.Countries.Dtos;
using kmgiasoc.Web.Pages.Countries.Country.ViewModels;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.Web.Pages.Cities.City.ViewModels;
using AutoMapper;

namespace kmgiasoc.Web
{
    public class kmgiasocWebAutoMapperProfile : Profile
    {
        public kmgiasocWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<DealCategoryDto, CreateEditDealCategoryViewModel>();
            CreateMap<CreateEditDealCategoryViewModel, CreateUpdateDealCategoryDto>();
            CreateMap<CreateDealViewModel, CreateDealDto>();
            CreateMap<DealDto, CreateEditDealViewModel>();
            CreateMap<CreateEditDealViewModel, CreateUpdateDealDto>();
            CreateMap<DealCategoryDto, EditDealCategoryViewModel>();
            CreateMap<CreateDealCategoryViewModel, DealCategoryCreateDto>();
            CreateMap<EditDealCategoryViewModel, DealCategoryUpdateDto>();
            CreateMap<CreateDealViewModel, DealCreateDto>();
            CreateMap<CountryDto, EditCountryViewModel>();
            CreateMap<CreateCountryViewModel, CountryCreateDto>();
            CreateMap<EditCountryViewModel, CountryUpdateDto>();
            CreateMap<CityDto, EditCityViewModel>();
            CreateMap<CreateCityViewModel, CityCreateDto>();
            CreateMap<EditCityViewModel, CityUpdateDto>();
        }
    }
}
