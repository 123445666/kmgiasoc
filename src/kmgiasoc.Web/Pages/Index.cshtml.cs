using kmgiasoc.Deals;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using System.Linq;
using kmgiasoc.Deals.Dtos;
using System.Collections.Generic;

namespace kmgiasoc.Web.Pages
{
    public class IndexModel : kmgiasocPageModel
    {
        private readonly IDealAppService _dealAppService;
        private readonly IDataFilter _dataFilter;

        public IList<DealDto> pagedResultDealDto { get; set; }


        public IndexModel(IDataFilter dataFilter, IDealAppService dealAppService)
        {
            _dataFilter = dataFilter;
            _dealAppService = dealAppService;
        }

        public virtual async Task OnGetAsync()
        {
            using (_dataFilter.Enable<IIsPublished>())
            {
                //PagedAndSortedResultRequestDto p = new PagedAndSortedResultRequestDto();
                //p.Sorting = "DealPriority DESC";
                //var result = await _dealAppService.GetListAsync(p);
                //pagedResultDealDto = result.Items.ToList();
            }
        }
    }
}