using System;
using System.Threading.Tasks;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Deals.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Deals
{
    public interface IDealAppService :
        ICrudAppService< 
            DealDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            DealCreateDto,
            DealUpdateDto>
    {
        Task<ListResultDto<DealCategoryDto>> GetDealCategoriesLookupAsync();

        Task<ListResultDto<CityDto>> GetCititesLookupAsync();
    }
}