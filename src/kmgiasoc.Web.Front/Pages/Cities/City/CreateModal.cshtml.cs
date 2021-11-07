using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Cities;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.Web.Pages.Cities.City.ViewModels;

namespace kmgiasoc.Web.Pages.Cities.City
{
    public class CreateModalModel : kmgiasocPageModel
    {
        [BindProperty]
        public CreateCityViewModel ViewModel { get; set; }

        private readonly ICityAppService _service;

        public CreateModalModel(ICityAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateCityViewModel, CityCreateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}