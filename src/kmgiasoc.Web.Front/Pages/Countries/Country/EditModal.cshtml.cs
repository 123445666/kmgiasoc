using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Countries;
using kmgiasoc.Countries.Dtos;
using kmgiasoc.Web.Pages.Countries.Country.ViewModels;

namespace kmgiasoc.Web.Pages.Countries.Country
{
    public class EditModalModel : kmgiasocPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public EditCountryViewModel ViewModel { get; set; }

        private readonly ICountryAppService _service;

        public EditModalModel(ICountryAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CountryDto, EditCountryViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditCountryViewModel, CountryUpdateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}