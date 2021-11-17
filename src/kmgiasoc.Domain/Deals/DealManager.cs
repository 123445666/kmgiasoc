using JetBrains.Annotations;
using kmgiasoc.Cities;
using kmgiasoc.DealCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;
using Volo.CmsKit.Users;

namespace kmgiasoc.Deals
{
    public class DealManager : DomainService
    {
        private readonly IDealRepository _repository;
        private readonly IDealCategoryRepository _dealCategoryRepository;

        public DealManager(IDealRepository repository, IDealCategoryRepository dealCategoryRepository)
        {
            _repository = repository;
            _dealCategoryRepository = dealCategoryRepository;
        }

        public virtual async Task<Deal> CreateAsync(
            string title,
            string slug,
            string shortDescription,
            string description,
            string link,
            string image,
            Guid? coverImageMediaId,
            DealCategory dealCategory,
            int dealPriority,
            decimal price,
            decimal pricePromo,
            bool freeShipping,
            decimal priceShipping,
            string codePromo,
            DateTime beginPromo,
            DateTime endPromo,
            City city,
            string localShop,
            int ratePoint,
            CmsUser author,
            bool isPublished,
            bool IsFeatured
            )
        {
            Check.NotNull(author, nameof(author));
            Check.NotNull(dealCategory, nameof(dealCategory));
            Check.NotNull(city, nameof(city));
            Check.NotNullOrEmpty(title, nameof(title));

            var deal = new Deal(
                        GuidGenerator.Create(),
                        title,
                        slug,
                        shortDescription,
                        description,
                        link,
                        image,
                        coverImageMediaId,
                        CurrentTenant.Id,
                        dealCategory.Id,
                        dealPriority,
                         price,
                         pricePromo,
                         freeShipping,
                         priceShipping,
                         codePromo,
                         beginPromo,
                         endPromo,
                         city.Id,
                         localShop,
                         ratePoint,
                         author.Id,
                         isPublished,
                         IsFeatured
                        );

            await CheckSlugExistenceAsync(deal.Slug);

            return deal;
        }

        public virtual async Task SetSlugUrlAsync(Deal deal, [NotNull] string newSlug)
        {
            Check.NotNullOrWhiteSpace(newSlug, nameof(newSlug));

            await CheckSlugExistenceAsync(newSlug);

            deal.SetSlug(newSlug);
        }

        protected virtual async Task CheckSlugExistenceAsync(string slug)
        {
            if (await _repository.SlugExistsAsync(slug))
            {
                throw new DealSlugAlreadyExistException(slug);
            }
        }

        protected virtual async Task CheckBlogExistenceAsync(Guid dealCategoryId)
        {
            if (!await _dealCategoryRepository.ExistsAsync(dealCategoryId))
            {
                throw new EntityNotFoundException(typeof(DealCategory), dealCategoryId);
            }
        }
    }
}
