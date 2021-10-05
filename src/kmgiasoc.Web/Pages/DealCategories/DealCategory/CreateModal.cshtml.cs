using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.DealCategories;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Web.Pages.DealCategories.DealCategory.ViewModels;

namespace kmgiasoc.Web.Pages.DealCategories.DealCategory
{
    public class CreateModalModel : kmgiasocPageModel
    {
        [BindProperty]
        public CreateDealCategoryViewModel ViewModel { get; set; }

        private readonly IDealCategoryAppService _service;

        public CreateModalModel(IDealCategoryAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateDealCategoryViewModel, DealCategoryCreateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}