using System.Threading.Tasks;
using JetBrains.Annotations;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Deals.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Front.Deals
{
    public interface IDealFrontAppService : IApplicationService
    {
        Task<ListResultDto<DealCategoryDto>> GetDealCategoriesLookupAsync();
        Task<ListResultDto<CityDto>> GetCititesLookupAsync();
        Task<PagedResultDto<DealDto>> GetListAsync([NotNull] string blogSlug, PagedAndSortedResultRequestDto input);
    }
}
