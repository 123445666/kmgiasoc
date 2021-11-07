using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Countries;
using kmgiasoc.Countries.Dtos;
using kmgiasoc.Web.Pages.Countries.Country.ViewModels;

namespace kmgiasoc.Web.Pages.Countries.Country
{
    public class CreateModalModel : kmgiasocPageModel
    {
        [BindProperty]
        public CreateCountryViewModel ViewModel { get; set; }

        private readonly ICountryAppService _service;

        public CreateModalModel(ICountryAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateCountryViewModel, CountryCreateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}