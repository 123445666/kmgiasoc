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

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    [Authorize("kmgiasoc.Deal.Create")]
    public class CreateModel : kmgiasocPageModel
    {
        [BindProperty]
        public CreateDealViewModel ViewModel { get; set; }
        [BindProperty]
        public UploadFileDto DealUploadFileDto { get; set; }
        public List<SelectListItem> DealCategories { get; set; }
        public List<SelectListItem> Citites { get; set; }

        private readonly IDealFrontAppService _service;
        private readonly IDealAppService _dealAppService;
        private readonly IFileAppService _fileAppService;

        public CreateModel(IDealFrontAppService service, IDealAppService dealAppService, IFileAppService fileAppService)
        {
            _service = service;
            _fileAppService = fileAppService;
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
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            string fileName = "";
            using (var memoryStream = new MemoryStream())
            {
                string fileExtension = Path.GetExtension(DealUploadFileDto.File.FileName);
                fileName = Path.ChangeExtension(Path.GetRandomFileName(), fileExtension);

                await DealUploadFileDto.File.CopyToAsync(memoryStream);

                await _fileAppService.SaveBlobAsync(
                    new SaveBlobInputDto
                    {
                        Name = fileName,
                        Content = memoryStream.ToArray()
                    }
                );
            }

            ViewModel.Image = fileName;
            ViewModel.Slug = SlugNormalizer.Normalize(ViewModel.Title);

            ViewModel.DealPriority = (int)DealEnum.Status.Draft;
            var dto = ObjectMapper.Map<CreateDealViewModel, DealCreateDto>(ViewModel);
            await _dealAppService.CreateAsync(dto);
            return RedirectToPage("/deals/deal/create");
            //return NoContent();
            //return Page();
        }
    }
}
