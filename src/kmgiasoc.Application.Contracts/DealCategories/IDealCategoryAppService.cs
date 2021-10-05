using System;
using kmgiasoc.DealCategories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.DealCategories
{
    public interface IDealCategoryAppService :
        ICrudAppService< 
            DealCategoryDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            DealCategoryCreateDto,
            DealCategoryUpdateDto>
    {

    }
}