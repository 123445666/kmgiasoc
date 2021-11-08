using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.CmsKit;
using Volo.CmsKit.Blogs;

namespace kmgiasoc.DealCategories
{
    public class DealCategory : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Slug { get; set; }
        public virtual Guid? TenantId { get; protected set; }
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
            Guid? tenantId,
            Nullable<Guid> parent,
            string description,
            int catOrder,
            DateTime publishDate,
            DateTime modifiedDate
        ) : base(id)
        {
            Name = name;
            SetSlug(slug);
            TenantId = tenantId;
            Parent = parent;
            Description = description;
            CatOrder = catOrder;
            PublishDate = publishDate;
            ModifiedDate = modifiedDate;
        }
        public virtual void SetSlug(string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug), BlogConsts.MaxNameLength);

            Slug = SlugNormalizer.Normalize(slug);
        }
    }
}
