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

        public DealSlugAlreadyExistException(string slug)
        {
            Slug = slug;

            Code = CmsKitErrorCodes.BlogPosts.SlugAlreadyExist;

            WithData(nameof(Slug), Slug);
        }

        public virtual string Slug { get; }

    }
}
