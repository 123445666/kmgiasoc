using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using kmgiasoc.DealCategories.Dtos;

namespace kmgiasoc.Front.DealCategories.Dtos
{
    public interface IDealCategoryFrontAppService : IApplicationService
    {
        Task<PagedResultDto<DealCategoryDto>> GetListAsync([NotNull] string blogSlug, PagedAndSortedResultRequestDto input);
    }
}
