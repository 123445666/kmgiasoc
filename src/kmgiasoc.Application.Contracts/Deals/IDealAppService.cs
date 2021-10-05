using System;
using kmgiasoc.Deals.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Deals
{
    public interface IDealAppService :
        ICrudAppService< 
            DealDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            DealCreateDto,
            DealUpdateDto>
    {

    }
}