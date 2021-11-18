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
using System.IO;
using kmgiasoc.FileUploader;
using Volo.CmsKit;
using kmgiasoc.Front.Deals;
using kmgiasoc.Utilities;
using System;

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    [Authorize("kmgiasoc.Deal.Update")]
    public class EditModel : kmgiasocPageModel
    {
        [BindProperty]
        public EditDealViewModel ViewModel { get; set; }
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public virtual Guid Id { get; set; }
        [BindProperty]
        public UploadFileDto DealUploadFileDto { get; set; }
        public List<SelectListItem> DealCategories { get; set; }
        public List<SelectListItem> Citites { get; set; }

        private readonly IDealFrontAppService _service;
        private readonly IDealAppService _dealAppService;

        public EditModel(IDealFrontAppService service, IDealAppService dealAppService)
        {
            _service = service;
            _dealAppService = dealAppService;
        }

        public virtual async Task OnGetAsync()
        {
            var dealCategoriesLookup = await _service.GetDealCategoriesLookupAsync();
            DealCategories = dealCategoriesLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            var citiesLookup = await _service.GetCititesLookupAsync();
            Citites = citiesLookup.Items.OrderBy(t => t.OrderCity)
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<DealDto, EditDealViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ViewModel.Image = DealUploadFileDto.File.FileName;

            var dto = ObjectMapper.Map<EditDealViewModel, DealUpdateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}
