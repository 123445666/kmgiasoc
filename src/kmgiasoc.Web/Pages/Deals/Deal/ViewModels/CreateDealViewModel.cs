using kmgiasoc.Cities;
using kmgiasoc.DealCategories;
using System;

using System.ComponentModel.DataAnnotations;
using Volo.CmsKit.Users;

namespace kmgiasoc.Web.Pages.Deals.Deal.ViewModels
{
    public class CreateDealViewModel
    {
        [Display(Name = "DealTitle")]
        public string Title { get; set; }

        [Display(Name = "DealSlug")]
        public string Slug { get; set; }

        [Display(Name = "DealShortDescription")]
        public string ShortDescription { get; set; }

        [Display(Name = "DealDescription")]
        public string Description { get; set; }

        [Display(Name = "DealLink")]
        public string Link { get; set; }

        [Display(Name = "DealDomainLink")]
        public string DomainLink { get; set; }

        [Display(Name = "DealImage")]
        public string Image { get; set; }

        [Display(Name = "DealCoverImageMediaId")]
        public Guid? CoverImageMediaId { get; set; }

        [Display(Name = "DealDealCategoryId")]
        public Guid DealCategoryId { get; set; }

        [Display(Name = "DealDealCategory")]
        public DealCategory DealCategory { get; set; }

        [Display(Name = "DealDealPriority")]
        public int DealPriority { get; set; }

        [Display(Name = "DealPrice")]
        public decimal Price { get; set; }

        [Display(Name = "DealPricePromo")]
        public decimal PricePromo { get; set; }

        [Display(Name = "DealFreeShipping")]
        public bool FreeShipping { get; set; }

        [Display(Name = "DealPriceShipping")]
        public decimal PriceShipping { get; set; }

        [Display(Name = "DealCodePromo")]
        public string CodePromo { get; set; }

        [Display(Name = "DealBeginPromo")]
        public DateTime BeginPromo { get; set; }

        [Display(Name = "DealEndPromo")]
        public DateTime EndPromo { get; set; }

        [Display(Name = "DealCityId")]
        public int CityId { get; set; }

        [Display(Name = "DealCity")]
        public City City { get; set; }

        [Display(Name = "DealLocalShop")]
        public string LocalShop { get; set; }

        [Display(Name = "DealPublishDate")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "DealModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "DealRatePoint")]
        public int RatePoint { get; set; }

        [Display(Name = "DealAuthorId")]
        public Guid AuthorId { get; set; }

        [Display(Name = "DealAuthor")]
        public CmsUser Author { get; set; }
    }
}