using kmgiasoc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace kmgiasoc.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class kmgiasocPageModel : AbpPageModel
    {
        protected kmgiasocPageModel()
        {
            LocalizationResourceType = typeof(kmgiasocResource);
        }
    }
}