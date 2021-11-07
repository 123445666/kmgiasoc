using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.DealCategories;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Web.Pages.DealCategories.DealCategory.ViewModels;

namespace kmgiasoc.Web.Pages.DealCategories.DealCategory
{
    public class EditModalModel : kmgiasocPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public EditDealCategoryViewModel ViewModel { get; set; }

        private readonly IDealCategoryAppService _service;

        public EditModalModel(IDealCategoryAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<DealCategoryDto, EditDealCategoryViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditDealCategoryViewModel, DealCategoryUpdateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}