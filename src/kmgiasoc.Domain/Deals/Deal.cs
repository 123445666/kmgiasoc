using kmgiasoc.Cities;
using kmgiasoc.DealCategories;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.CmsKit;
using Volo.CmsKit.Users;

namespace kmgiasoc.Deals
{
    public class Deal : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; protected set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string DomainLink { get; set; }
        public string Image { get; set; }
        public Guid? CoverImageMediaId { get; set; }
        public Guid? TenantId { get; protected set; }
        public Guid DealCategoryId { get; set; }
        public DealCategory DealCategory { get; set; }
        public int DealPriority { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PricePromo { get; set; }
        public bool FreeShipping { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PriceShipping { get; set; }
        public string CodePromo { get; set; }
        public DateTime BeginPromo { get; set; }
        public DateTime EndPromo { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
        public string LocalShop { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RatePoint { get; set; }
        public Guid AuthorId { get; set; }
        public virtual CmsUser Author { get; set; }

        protected Deal()
        {
        }

        public Deal(
            Guid id,
            string title,
            string slug,
            string shortDescription,
            string description,
            string link,
            string image,
            Guid? coverImageMediaId,
            Guid? tenantId,
            Guid dealCategoryId,
            int dealPriority,
            decimal price,
            decimal pricePromo,
            bool freeShipping,
            decimal priceShipping,
            string codePromo,
            DateTime beginPromo,
            DateTime endPromo,
            int cityId,
            string localShop,
            DateTime publishDate,
            DateTime modifiedDate,
            int ratePoint,
            Guid authorId
        ) : base(id)
        {
            SetTitle(title);
            SetSlug(title);
            SetShortDescription(shortDescription);
            SetContent(description);
            Link = link;
            SetDomainLink(link);
            Image = image;
            CoverImageMediaId = coverImageMediaId;
            TenantId = tenantId;
            DealCategoryId = dealCategoryId;
            DealPriority = dealPriority;
            Price = price;
            PricePromo = pricePromo;
            FreeShipping = freeShipping;
            PriceShipping = priceShipping;
            CodePromo = codePromo;
            BeginPromo = beginPromo;
            EndPromo = endPromo;
            CityId = cityId;
            LocalShop = localShop;
            PublishDate = publishDate;
            ModifiedDate = modifiedDate;
            RatePoint = ratePoint;
            AuthorId = authorId;
        }

        public virtual void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title), DealConsts.MaxTitleLength);
        }

        internal void SetSlug(string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug), DealConsts.MaxSlugLength, DealConsts.MinSlugLength);

            Slug = SlugNormalizer.Normalize(slug);
        }

        public virtual void SetShortDescription(string shortDescription)
        {
            ShortDescription = Check.Length(shortDescription, nameof(shortDescription), DealConsts.MaxShortDescriptionLength);
        }

        public virtual void SetContent(string description)
        {
            description = Check.Length(description, nameof(description), DealConsts.MaxContentLength);
        }

        public virtual void SetDomainLink(string link)
        {
            Uri myUri = new Uri(link);
            DomainLink = myUri.Host;
            
        }
    }
}
