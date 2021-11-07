using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.CmsKit;

namespace kmgiasoc.DealCategories
{
    class DealCategoriesDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<DealCategory, Guid> _dealCategoryRepository;
        public DealCategoriesDataSeedContributor(
            IRepository<DealCategory, Guid> dealCategoryRepository)
        {
            _dealCategoryRepository = dealCategoryRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _dealCategoryRepository.GetCountAsync() > 0)
            {
                return;
            }

            List<string> CategoriesString = new List<string>{ "Công nghệ cao", "Ôtô",
                "Bảng điều khiển & trò chơi điện tử","Văn hóa & Giải trí",
                "Cửa hàng tạp hóa & cửa hàng tạp hóa","Thể thao & Ngoài trời","Phụ kiện thời trang",
                "Gói di động và internet","Sức khỏe & Mỹ phẩm",
                "Gia đình & Trẻ em","Gói di động và internet",
                "Nhà & Môi trường sống","Tài chính & Bảo hiểm",
                "Vườn & Tự làm","Dịch vụ","Du lịch"
            };

            int i = 1;
            foreach (string cat in CategoriesString)
            {
                await _dealCategoryRepository.InsertAsync(
                new DealCategory(Guid.NewGuid(), cat, SlugNormalizer.Normalize(cat), "", i++, DateTime.Now, DateTime.Now),
                autoSave: true
            );
            }
        }
    }
}
