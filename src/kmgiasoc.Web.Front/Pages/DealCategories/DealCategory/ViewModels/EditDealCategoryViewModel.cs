using System;

using System.ComponentModel.DataAnnotations;

namespace kmgiasoc.Web.Pages.DealCategories.DealCategory.ViewModels
{
    public class EditDealCategoryViewModel
    {
        [Display(Name = "DealCategoryName")]
        public string Name { get; set; }

        [Display(Name = "DealCategoryParent")]
        public Guid Parent { get; set; }

        [Display(Name = "DealCategoryDescription")]
        public string Description { get; set; }

        [Display(Name = "DealCategoryCatOrder")]
        public int CatOrder { get; set; }

        [Display(Name = "DealCategoryPublishDate")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "DealCategoryModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}