using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace kmgiasoc.Web
{
    [Dependency(ReplaceServices = true)]
    public class kmgiasocBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "kmgiasoc";
    }
}
