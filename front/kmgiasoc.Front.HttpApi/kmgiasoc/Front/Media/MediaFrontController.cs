using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.Admin;
using Volo.CmsKit.Admin.MediaDescriptors;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Permissions;

namespace kmgiasoc.kmgiasoc.Front.Media
{
    [RequiresGlobalFeature(typeof(MediaFeature))]
    [RemoteService(Name = CmsKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Route("api/deal-kit-front/media")]
    public class MediaFrontController : CmsKitAdminController, IMediaDescriptorAdminAppService
    {
        protected readonly IMediaDescriptorAdminAppService MediaDescriptorAdminAppService;

        public MediaFrontController(IMediaDescriptorAdminAppService mediaDescriptorAdminAppService)
        {
            MediaDescriptorAdminAppService = mediaDescriptorAdminAppService;
        }

        [HttpPost]
        [Route("{entityType}")]
        public virtual Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream)
        {
            return MediaDescriptorAdminAppService.CreateAsync(entityType, inputStream);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return MediaDescriptorAdminAppService.DeleteAsync(id);
        }
    }
}
