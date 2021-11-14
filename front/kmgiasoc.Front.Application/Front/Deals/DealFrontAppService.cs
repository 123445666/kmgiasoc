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
using Volo.CmsKit.Users;
using Microsoft.AspNetCore.Authorization;
using kmgiasoc.Permissions;
using System;
using Volo.Abp.Users;
using System.Linq;

namespace kmgiasoc.Front.Deals
{
    public class DealFrontAppService : kmgiasocAppService, IDealFrontAppService
    {
        private readonly DealManager _dealManager;

        private readonly IDealRepository _repository;
        private readonly IDealCategoryRepository _dealCategoryRepository;
        private readonly ICityRepository _cityRepository;

        private readonly ICmsUserLookupService _userLookupService;

        public DealFrontAppService(DealManager dealManager, IDealRepository repository, IDealCategoryRepository dealCategoryRepository,
            ICityRepository cityRepository,
            ICmsUserLookupService userLookupService)
        {
            _repository = repository;
            _dealCategoryRepository = dealCategoryRepository;
            _cityRepository = cityRepository;
            _dealManager = dealManager;
            _userLookupService = userLookupService;
        }

        #region CRUD 
        [Authorize(kmgiasocPermissions.Deal.Create)]
        public virtual async Task<DealDto> CreateAsync(DealCreateDto input)
        {
            var author = await _userLookupService.GetByIdAsync(CurrentUser.GetId());

            var dealCategory = await _dealCategoryRepository.GetAsync(input.DealCategoryId);

            var city = await _cityRepository.GetAsync(input.CityId);

            var deal = await _dealManager.CreateAsync(
                                                        input.Title,
                                                        input.Slug,
                                                        input.ShortDescription,
                                                        input.Description,
                                                        input.Link,
                                                        input.Image,
                                                        input.CoverImageMediaId,
                                                        dealCategory,
                                                        input.DealPriority,
                                                        input.Price,
                                                        input.PricePromo,
                                                        input.FreeShipping,
                                                        input.PriceShipping,
                                                        input.CodePromo,
                                                        input.BeginPromo,
                                                        input.EndPromo,
                                                        city,
                                                        input.LocalShop,
                                                        input.PublishDate,
                                                        input.ModifiedDate,
                                                        input.RatePoint,
                                                        author
                                                        );

            await _repository.InsertAsync(deal);

            return ObjectMapper.Map<Deal, DealDto>(deal);
        }

        [Authorize(kmgiasocPermissions.Deal.Update)]
        public virtual async Task<DealDto> UpdateAsync(Guid id, DealUpdateDto input)
        {
            var deal = await _repository.GetAsync(id);

            deal.SetTitle(input.Title);
            deal.SetShortDescription(input.ShortDescription);
            deal.SetContent(input.Description);
            deal.SetDomainLink(input.Link);
            deal.CoverImageMediaId = input.CoverImageMediaId;

            if (deal.Slug != input.Slug)
            {
                await _dealManager.SetSlugUrlAsync(deal, input.Slug);
            }

            await _repository.UpdateAsync(deal);

            return ObjectMapper.Map<Deal, DealDto>(deal);
        }

        [Authorize(kmgiasocPermissions.Deal.Default)]
        public virtual async Task<DealDto> GetAsync(Guid id)
        {
            var deal = await _repository.GetAsync(id);

            return ObjectMapper.Map<Deal, DealDto>(deal);
        }

        [Authorize(kmgiasocPermissions.Deal.Default)]
        public virtual async Task<PagedResultDto<DealDto>> GetListAsync(DealGetListInput input)
        {
            var dealCategories = (await _dealCategoryRepository.GetListAsync()).ToDictionary(x => x.Id);

            var deals = await _repository.GetListAsync(input.Filter, input.dealCategoryId, input.MaxResultCount, input.SkipCount, input.Sorting);

            var count = await _repository.GetCountAsync(input.Filter);

            var dtoList = deals.Select(x =>
            {
                var dto = ObjectMapper.Map<Deal, DealDto>(x);
                dto.Title = dealCategories[x.DealCategoryId].Name;

                return dto;
            }).ToList();

            return new PagedResultDto<DealDto>(count, dtoList);
        }

        [Authorize(kmgiasocPermissions.Deal.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        #endregion

        #region LookupData
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
        #endregion
    }
}
