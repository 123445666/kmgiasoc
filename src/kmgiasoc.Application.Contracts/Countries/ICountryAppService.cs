using System;
using kmgiasoc.Countries.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Countries
{
    public interface ICountryAppService :
        ICrudAppService< 
            CountryDto, 
            int, 
            PagedAndSortedResultRequestDto,
            CountryCreateDto,
            CountryUpdateDto>
    {

    }
}