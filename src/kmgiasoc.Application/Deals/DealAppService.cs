using System;
using kmgiasoc.Permissions;
using kmgiasoc.Deals.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.DealCategories;
using System.Collections.Generic;

namespace kmgiasoc.Deals
{
    public class DealAppService : CrudAppService<Deal, DealDto, Guid, PagedAndSortedResultRequestDto, DealCreateDto, DealUpdateDto>,
        IDealAppService
    {
        protected override string GetPolicyName { get; set; } = kmgiasocPermissions.Deal.Default;
        protected override string GetListPolicyName { get; set; } = kmgiasocPermissions.Deal.Default;
        protected override string CreatePolicyName { get; set; } = kmgiasocPermissions.Deal.Create;
        protected override string UpdatePolicyName { get; set; } = kmgiasocPermissions.Deal.Update;
        protected override string DeletePolicyName { get; set; } = kmgiasocPermissions.Deal.Delete;

        private readonly IDealRepository _repository;
        private readonly IDealCategoryRepository _dealCategoryRepository;
        
        public DealAppService(IDealRepository repository, IDealCategoryRepository dealCategoryRepository) : base(repository)
        {
            _repository = repository;
            _dealCategoryRepository = dealCategoryRepository;
        }

        public async Task<ListResultDto<DealCategoryDto>> GetDealCategoriesLookupAsync()
        {
            var dealCategories = await _dealCategoryRepository.GetListAsync();

            return new ListResultDto<DealCategoryDto>(
                ObjectMapper.Map<List<DealCategory>, List<DealCategoryDto>>(dealCategories)
            );
        }
    }
}
