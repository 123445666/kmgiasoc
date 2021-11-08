using kmgiasoc.Cities;
using kmgiasoc.DealCategories;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
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
            string domainLink,
            string image,
            Guid? coverImageMediaId,
            Guid? tenantId,
            Guid dealCategoryId,
            DealCategory dealCategory,
            int dealPriority,
            decimal price,
            decimal pricePromo,
            bool freeShipping,
            decimal priceShipping,
            string codePromo,
            DateTime beginPromo,
            DateTime endPromo,
            int cityId,
            City city,
            string localShop,
            DateTime publishDate,
            DateTime modifiedDate,
            int ratePoint,
            Guid authorId,
            CmsUser author
        ) : base(id)
        {
            Title = title;
            Slug = slug;
            ShortDescription = shortDescription;
            Description = description;
            Link = link;
            DomainLink = domainLink;
            Image = image;
            CoverImageMediaId = coverImageMediaId;
            TenantId = tenantId;
            DealCategoryId = dealCategoryId;
            DealCategory = dealCategory;
            DealPriority = dealPriority;
            Price = price;
            PricePromo = pricePromo;
            FreeShipping = freeShipping;
            PriceShipping = priceShipping;
            CodePromo = codePromo;
            BeginPromo = beginPromo;
            EndPromo = endPromo;
            CityId = cityId;
            City = city;
            LocalShop = localShop;
            PublishDate = publishDate;
            ModifiedDate = modifiedDate;
            RatePoint = ratePoint;
            AuthorId = authorId;
            Author = author;
        }
    }
}
