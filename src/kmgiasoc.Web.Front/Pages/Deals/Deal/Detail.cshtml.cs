using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Deals;
using kmgiasoc.Deals.Dtos;
using Microsoft.AspNetCore.Authorization;
using kmgiasoc.Front.Deals;

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    public class DetailModel : kmgiasocPageModel
    {
        [BindProperty(SupportsGet = true)]
        public string DealSlug { get; set; }
        public DealDto Deal { get; private set; }

        private readonly IDealFrontAppService _service;
        private readonly IDealAppService _dealAppService;

        public DetailModel(IDealFrontAppService service, IDealAppService dealAppService)
        {
            _service = service;
            _dealAppService = dealAppService;
        }

        public virtual async Task OnGetAsync()
        {
            Deal = await _service.GetAsync(DealSlug);
        }
    }
}
