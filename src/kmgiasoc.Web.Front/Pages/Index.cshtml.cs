using kmgiasoc.Deals;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using System.Linq;
using kmgiasoc.Deals.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Front.Deals;

namespace kmgiasoc.Web.Pages
{
    public class IndexModel : kmgiasocPageModel
    {
        public const int PageSize = 12;
        public int CurrentPage { get; set; } = 1;

        private readonly IDealFrontAppService _dealFrontAppService;
        private readonly IDataFilter _dataFilter;

        public PagedResultDto<DealDto> pagedResultDealDto { get; set; }
        [BindProperty(SupportsGet = true)]
        public string dealCategorySlug { get; set; }

        public IndexModel(IDataFilter dataFilter, IDealFrontAppService dealFrontAppService)
        {
            _dataFilter = dataFilter;
            _dealFrontAppService = dealFrontAppService;
        }

        public virtual async Task OnGetAsync()
        {
            pagedResultDealDto = await _dealFrontAppService.GetPublishedListAsync(
                dealCategorySlug,
                new PagedAndSortedResultRequestDto
                {
                    SkipCount = PageSize * (CurrentPage - 1),
                    MaxResultCount = PageSize
                });
        }
    }
}