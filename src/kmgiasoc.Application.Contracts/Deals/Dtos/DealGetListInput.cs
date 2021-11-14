using System;
using Volo.Abp.Application.Dtos;

namespace kmgiasoc.Deals.Dtos
{
    public class DealGetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public Guid? dealCategoryId { get; set; }
    }
}
