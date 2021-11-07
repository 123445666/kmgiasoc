using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kmgiasoc.Cities;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.Web.Pages.Cities.City.ViewModels;

namespace kmgiasoc.Web.Pages.Cities.City
{
    public class EditModalModel : kmgiasocPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public EditCityViewModel ViewModel { get; set; }

        private readonly ICityAppService _service;

        public EditModalModel(ICityAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CityDto, EditCityViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditCityViewModel, CityUpdateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}