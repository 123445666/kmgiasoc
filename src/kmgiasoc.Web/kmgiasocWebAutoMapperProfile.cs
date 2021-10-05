using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Web.Pages.DealCategories.DealCategory.ViewModels;
using kmgiasoc.Deals.Dtos;
using kmgiasoc.Web.Pages.Deals.Deal.ViewModels;
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
            CreateMap<DealDto, EditDealViewModel>();
            CreateMap<CreateDealViewModel, CreateDealDto>();
            CreateMap<EditDealViewModel, UpdateDealDto>();
            CreateMap<DealDto, CreateEditDealViewModel>();
            CreateMap<CreateEditDealViewModel, CreateUpdateDealDto>();
            CreateMap<DealCategoryDto, EditDealCategoryViewModel>();
            CreateMap<CreateDealCategoryViewModel, DealCategoryCreateDto>();
            CreateMap<EditDealCategoryViewModel, DealCategoryUpdateDto>();
            CreateMap<DealDto, EditDealViewModel>();
            CreateMap<CreateDealViewModel, DealCreateDto>();
            CreateMap<EditDealViewModel, DealUpdateDto>();
        }
    }
}
