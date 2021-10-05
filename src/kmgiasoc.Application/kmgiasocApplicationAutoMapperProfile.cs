using kmgiasoc.DealCategories;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Deals;
using kmgiasoc.Deals.Dtos;
using AutoMapper;

namespace kmgiasoc
{
    public class kmgiasocApplicationAutoMapperProfile : Profile
    {
        public kmgiasocApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
           
            CreateMap<DealCategory, DealCategoryDto>();
            CreateMap<CreateUpdateDealCategoryDto, DealCategory>(MemberList.Source);
            CreateMap<Deal, DealDto>();
            CreateMap<CreateDealDto, Deal>(MemberList.Source);
            CreateMap<UpdateDealDto, Deal>(MemberList.Source);
            CreateMap<Deal, DealDto>();
            CreateMap<CreateUpdateDealDto, Deal>(MemberList.Source);
            CreateMap<DealCategory, DealCategoryDto>();
            CreateMap<DealCategoryCreateDto, DealCategory>(MemberList.Source);
            CreateMap<DealCategoryUpdateDto, DealCategory>(MemberList.Source);
            CreateMap<Deal, DealDto>();
            CreateMap<DealCreateDto, Deal>(MemberList.Source);
            CreateMap<DealUpdateDto, Deal>(MemberList.Source);
        }
    }
}
