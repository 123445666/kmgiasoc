using System.Threading.Tasks;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.DealCategories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.kmgiasoc.Front.Deals
{
    public interface IDealFrontAppService : IApplicationService
    {
        Task<ListResultDto<DealCategoryDto>> GetDealCategoriesLookupAsync();
        Task<ListResultDto<CityDto>> GetCititesLookupAsync();
    }
}
