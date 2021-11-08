using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace kmgiasoc.DealCategories
{
    public class DealCategory : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Nullable<Guid> Parent { get; set; }
        public string Description { get; set; }
        public int CatOrder { get; set; }

        public DateTime PublishDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        protected DealCategory()
        {
        }


        public DealCategory(
            Guid id,
            string name,
            string slug,
            Nullable<Guid> parent,
            string description,
            int catOrder,
            DateTime publishDate,
            DateTime modifiedDate
        ) : base(id)
        {
            Name = name;
            Slug = slug;
            Parent = parent;
            Description = description;
            CatOrder = catOrder;
            PublishDate = publishDate;
            ModifiedDate = modifiedDate;
        }
    }
}
