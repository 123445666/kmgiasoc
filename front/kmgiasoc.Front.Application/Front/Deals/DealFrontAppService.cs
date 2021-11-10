using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.DealCategories;
using System.Collections.Generic;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.Cities;
using kmgiasoc.Deals;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Front.Deals
{
    public class DealFrontAppService : ApplicationService, IDealFrontAppService
    {
        private readonly IDealRepository _repository;
        private readonly IDealCategoryRepository _dealCategoryRepository;
        private readonly ICityRepository _cityRepository;

        public DealFrontAppService(IDealRepository repository, IDealCategoryRepository dealCategoryRepository,
            ICityRepository cityRepository)
        {
            _repository = repository;
            _dealCategoryRepository = dealCategoryRepository;
            _cityRepository = cityRepository;
        }

        public async Task<ListResultDto<DealCategoryDto>> GetDealCategoriesLookupAsync()
        {
            var dealCategories = await _dealCategoryRepository.GetListAsync();

            return new ListResultDto<DealCategoryDto>(
                ObjectMapper.Map<List<DealCategory>, List<DealCategoryDto>>(dealCategories)
            );
        }

        public async Task<ListResultDto<CityDto>> GetCititesLookupAsync()
        {
            var citites = await _cityRepository.GetListAsync();

            return new ListResultDto<CityDto>(
                ObjectMapper.Map<List<City>, List<CityDto>>(citites)
            );
        }

        Task<ListResultDto<DealCategoryDto>> IDealFrontAppService.GetDealCategoriesLookupAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<ListResultDto<CityDto>> IDealFrontAppService.GetCititesLookupAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
