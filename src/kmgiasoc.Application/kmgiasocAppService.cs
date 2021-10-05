using System;
using System.Collections.Generic;
using System.Text;
using kmgiasoc.Localization;
using Volo.Abp.Application.Services;

namespace kmgiasoc
{
    /* Inherit your application services from this class.
     */
    public abstract class kmgiasocAppService : ApplicationService
    {
        protected kmgiasocAppService()
        {
            LocalizationResource = typeof(kmgiasocResource);
        }
    }
}
