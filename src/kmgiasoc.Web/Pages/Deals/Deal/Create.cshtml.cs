using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Deals;
using kmgiasoc.Deals.Dtos;
using kmgiasoc.Web.Pages.Deals.Deal.ViewModels;

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    public class CreateModel : kmgiasocPageModel
    {
        [BindProperty]
        public CreateDealViewModel ViewModel { get; set; }

        private readonly IDealAppService _service;

        public CreateModel(IDealAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateDealViewModel, DealCreateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}
