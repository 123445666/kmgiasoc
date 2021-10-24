using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Deals;
using kmgiasoc.Deals.Dtos;
using kmgiasoc.Web.Pages.Deals.Deal.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    public class CreateModalModel : kmgiasocPageModel
    {
        [BindProperty]
        public CreateDealViewModel ViewModel { get; set; }
        public List<SelectListItem> DealCategories { get; set; }


        private readonly IDealAppService _service;

        public CreateModalModel(IDealAppService service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {
            ViewModel = new CreateDealViewModel();

            var dealCategoriesLookup = await _service.GetDealCategoriesLookupAsync();
            DealCategories = dealCategoriesLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateDealViewModel, DealCreateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}