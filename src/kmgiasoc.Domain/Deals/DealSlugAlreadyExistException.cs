using System;
using System.Runtime.Serialization;
using Volo.Abp;
using Volo.CmsKit;

namespace kmgiasoc.Deals
{
    public class DealSlugAlreadyExistException : BusinessException
    {
        public DealSlugAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
        }

        public DealSlugAlreadyExistException(Guid dealCategoryId, string slug)
        {
            Slug = slug;
            DealCategoryId = dealCategoryId;

            Code = CmsKitErrorCodes.BlogPosts.SlugAlreadyExist;

            WithData(nameof(Slug), Slug);
            WithData(nameof(DealCategoryId), DealCategoryId);
        }

        public virtual string Slug { get; }

        public virtual Guid DealCategoryId { get; }
    }
}
