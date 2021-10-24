using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace kmgiasoc.Deals
{
    public class Deal : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string DomainLink { get; set; }
        public string Image { get; set; }
        [ForeignKey("DealCategory")]
        public Guid DealCategoryId { get; set; }
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
        public string City { get; set; }
        public string LocalShop { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        protected Deal()
        {
        }

        public Deal(
            Guid id,
            string title,
            string description,
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
            DateTime modifiedDate
        ) : base(id)
        {
            Title = title;
            Description = description;
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
        }

        public Deal(
            Guid id,
            string title,
            string description,
            string link,
            string domainLink,
            string image,
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
            string city,
            string localShop,
            DateTime publishDate,
            DateTime modifiedDate
        ) : base(id)
        {
            Title = title;
            Description = description;
            Link = link;
            DomainLink = domainLink;
            Image = image;
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
            City = city;
            LocalShop = localShop;
            PublishDate = publishDate;
            ModifiedDate = modifiedDate;
        }
    }
}
