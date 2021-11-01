using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Deals;
using kmgiasoc.Deals.Dtos;
using kmgiasoc.Web.Pages.Deals.Deal.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using kmgiasoc.Web.Pages.Files;

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    [Authorize("kmgiasoc.Deal.Create")]
    public class CreateModel : kmgiasocPageModel
    {
        [BindProperty]
        public CreateDealViewModel ViewModel { get; set; }
        [BindProperty]
        public UploadFileDto UploadFileDto { get; set; }
        public List<SelectListItem> DealCategories { get; set; }

        private readonly IDealAppService _service;

        public CreateModel(IDealAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dealCategoriesLookup = await _service.GetDealCategoriesLookupAsync();
            DealCategories = dealCategoriesLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateDealViewModel, DealCreateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return RedirectToPage("/deals/deal/create");
            //return NoContent();
            //return Page();
        }
    }
}
