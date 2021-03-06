using System;
using System.ComponentModel;
namespace kmgiasoc.Deals.Dtos
{
    [Serializable]
    public class CreateDealDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid DealCategoryId { get; set; }

        public int DealPriority { get; set; }

        public decimal Price { get; set; }

        public decimal PricePromo { get; set; }

        public bool FreeShipping { get; set; }

        public decimal PriceShipping { get; set; }

        public string CodePromo { get; set; }

        public DateTime BeginPromo { get; set; }

        public DateTime EndPromo { get; set; }

        public Guid CityId { get; set; }

        public string LocalShop { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}