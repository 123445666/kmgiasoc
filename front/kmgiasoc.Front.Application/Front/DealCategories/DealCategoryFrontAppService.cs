using JetBrains.Annotations;
using kmgiasoc.DealCategories;
using kmgiasoc.DealCategories.Dtos;
using kmgiasoc.Front.DealCategories.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace kmgiasoc.Front.DealCategories
{
    public class DealCategoryFrontAppService : ApplicationService, IDealCategoryFrontAppService
    {
        protected IDealCategoryRepository _dealCategoryRepository { get; }

        public DealCategoryFrontAppService(
            IDealCategoryRepository dealCategoryRepository)
        {
            _dealCategoryRepository = dealCategoryRepository;
        }

        public Task<PagedResultDto<DealCategoryDto>> GetListAsync([NotNull] string blogSlug, PagedAndSortedResultRequestDto input)
        {
            //var blog = await BlogRepository.GetBySlugAsync(blogSlug);

            //var blogPosts = await BlogPostRepository.GetListAsync(null, blog.Id, input.MaxResultCount, input.SkipCount, input.Sorting);

            //return new PagedResultDto<BlogPostPublicDto>(
            //    await BlogPostRepository.GetCountAsync(blogId: blog.Id),
            //    ObjectMapper.Map<List<BlogPost>, List<BlogPostPublicDto>>(blogPosts));

            throw new System.NotImplementedException();
        }
    }
}
