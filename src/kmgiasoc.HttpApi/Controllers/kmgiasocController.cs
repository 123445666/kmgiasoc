using kmgiasoc.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace kmgiasoc.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class kmgiasocController : AbpController
    {
        protected kmgiasocController()
        {
            LocalizationResource = typeof(kmgiasocResource);
        }
    }
}