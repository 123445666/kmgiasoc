using System;
using System.ComponentModel;

namespace kmgiasoc.DealCategories.Dtos
{
    [Serializable]
    public class DealCategoryUpdateDto
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public Nullable<Guid> Parent { get; set; }

        public string Description { get; set; }

        public int CatOrder { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}