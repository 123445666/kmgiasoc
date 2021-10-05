using System;
using Volo.Abp.Application.Dtos;

namespace kmgiasoc.DealCategories.Dtos
{
    [Serializable]
    public class DealCategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid Parent { get; set; }

        public string Description { get; set; }

        public int CatOrder { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}