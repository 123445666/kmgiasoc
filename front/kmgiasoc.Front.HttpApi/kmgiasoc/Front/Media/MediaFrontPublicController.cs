using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.MediaDescriptors;

namespace kmgiasoc.kmgiasoc.Front.Media
{
    [RequiresGlobalFeature(typeof(MediaFeature))]
    [RemoteService(Name = CmsKitCommonRemoteServiceConsts.RemoteServiceName)]
    [Route("api/media")]
    public class MediaDescriptorController : CmsKitControllerBase, IMediaDescriptorAppService
    {
        protected readonly IMediaDescriptorAppService MediaDescriptorAppService;

        public MediaDescriptorController(IMediaDescriptorAppService mediaDescriptorAppService)
        {
            MediaDescriptorAppService = mediaDescriptorAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RemoteStreamContent> DownloadAsync(Guid id)
        {
            return MediaDescriptorAppService.DownloadAsync(id);
        }
    }
}