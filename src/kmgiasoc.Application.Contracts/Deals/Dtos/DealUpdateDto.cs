using kmgiasoc.Cities.Dtos;
using kmgiasoc.DealCategories.Dtos;
using System;
using System.ComponentModel;
using Volo.CmsKit.Users;

namespace kmgiasoc.Deals.Dtos
{
    [Serializable]
    public class DealUpdateDto
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string DomainLink { get; set; }

        public string Image { get; set; }

        public Guid? CoverImageMediaId { get; set; }

        public Guid DealCategoryId { get; set; }

        public DealCategoryDto DealCategory { get; set; }

        public int DealPriority { get; set; }

        public decimal Price { get; set; }

        public decimal PricePromo { get; set; }

        public bool FreeShipping { get; set; }

        public decimal PriceShipping { get; set; }

        public string CodePromo { get; set; }

        public DateTime BeginPromo { get; set; }

        public DateTime EndPromo { get; set; }

        public int CityId { get; set; }

        public CityDto City { get; set; }

        public string LocalShop { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int RatePoint { get; set; }

        public Guid AuthorId { get; set; }

        public CmsUserDto Author { get; set; }
    }
}