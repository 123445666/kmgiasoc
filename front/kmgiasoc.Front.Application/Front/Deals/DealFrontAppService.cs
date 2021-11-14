using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.DealCategories;
using System.Collections.Generic;
using kmgiasoc.Cities.Dtos;
using kmgiasoc.Cities;
using kmgiasoc.Deals;
using Volo.Abp.Application.Services;
using JetBrains.Annotations;
using kmgiasoc.Deals.Dtos;

namespace kmgiasoc.Front.Deals
{
    public class DealFrontAppService : kmgiasocAppService, IDealFrontAppService
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

        public virtual async Task<PagedResultDto<DealDto>> GetListAsync([NotNull] string dealCategorSlug, PagedAndSortedResultRequestDto input)
        {
            if (!string.IsNullOrEmpty(dealCategorSlug))
            {
                var dealCategory = await _dealCategoryRepository.GetBySlugAsync(dealCategorSlug);

                var deals = await _repository.GetListAsync(null, dealCategory.Id, input.MaxResultCount, input.SkipCount, input.Sorting);
                return new PagedResultDto<DealDto>(
                    await _repository.GetCountAsync(dealCategoryId: dealCategory.Id),
                    ObjectMapper.Map<List<Deal>, List<DealDto>>(deals));
            }

            var _deals = await _repository.GetListAsync(null, null, input.MaxResultCount, input.SkipCount, input.Sorting);
            return new PagedResultDto<DealDto>(
                await _repository.GetCountAsync(dealCategoryId: null),
                ObjectMapper.Map<List<Deal>, List<DealDto>>(_deals));

        }
    }
}
