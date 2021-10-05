using System;
using kmgiasoc.Permissions;
using kmgiasoc.DealCategories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.DealCategories
{
    public class DealCategoryAppService : CrudAppService<DealCategory, DealCategoryDto, Guid, PagedAndSortedResultRequestDto, DealCategoryCreateDto, DealCategoryUpdateDto>,
        IDealCategoryAppService
    {
        protected override string GetPolicyName { get; set; } = kmgiasocPermissions.DealCategory.Default;
        protected override string GetListPolicyName { get; set; } = kmgiasocPermissions.DealCategory.Default;
        protected override string CreatePolicyName { get; set; } = kmgiasocPermissions.DealCategory.Create;
        protected override string UpdatePolicyName { get; set; } = kmgiasocPermissions.DealCategory.Update;
        protected override string DeletePolicyName { get; set; } = kmgiasocPermissions.DealCategory.Delete;

        private readonly IDealCategoryRepository _repository;
        
        public DealCategoryAppService(IDealCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
