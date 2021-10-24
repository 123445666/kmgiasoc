using System;
using kmgiasoc.Cities.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Cities
{
    public interface ICityAppService :
        ICrudAppService< 
            CityDto, 
            int, 
            PagedAndSortedResultRequestDto,
            CityCreateDto,
            CityUpdateDto>
    {

    }
}