using System;
using kmgiasoc.Permissions;
using kmgiasoc.Cities.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Cities
{
    public class CityAppService : CrudAppService<City, CityDto, int, PagedAndSortedResultRequestDto, CityCreateDto, CityUpdateDto>,
        ICityAppService
    {
        protected override string GetPolicyName { get; set; } = kmgiasocPermissions.City.Default;
        protected override string GetListPolicyName { get; set; } = kmgiasocPermissions.City.Default;
        protected override string CreatePolicyName { get; set; } = kmgiasocPermissions.City.Create;
        protected override string UpdatePolicyName { get; set; } = kmgiasocPermissions.City.Update;
        protected override string DeletePolicyName { get; set; } = kmgiasocPermissions.City.Delete;

        private readonly ICityRepository _repository;
        
        public CityAppService(ICityRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
