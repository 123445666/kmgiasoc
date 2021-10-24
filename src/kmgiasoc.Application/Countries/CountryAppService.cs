using System;
using kmgiasoc.Permissions;
using kmgiasoc.Countries.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Countries
{
    public class CountryAppService : CrudAppService<Country, CountryDto, int, PagedAndSortedResultRequestDto, CountryCreateDto, CountryUpdateDto>,
        ICountryAppService
    {
        protected override string GetPolicyName { get; set; } = kmgiasocPermissions.Country.Default;
        protected override string GetListPolicyName { get; set; } = kmgiasocPermissions.Country.Default;
        protected override string CreatePolicyName { get; set; } = kmgiasocPermissions.Country.Create;
        protected override string UpdatePolicyName { get; set; } = kmgiasocPermissions.Country.Update;
        protected override string DeletePolicyName { get; set; } = kmgiasocPermissions.Country.Delete;

        private readonly ICountryRepository _repository;
        
        public CountryAppService(ICountryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
