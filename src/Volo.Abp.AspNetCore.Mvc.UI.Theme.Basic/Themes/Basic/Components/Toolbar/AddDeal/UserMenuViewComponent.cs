using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Themes.Basic.Components.Toolbar.UserMenu
{
    public class AddDealViewComponent : AbpViewComponent
    {

        public AddDealViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Themes/Basic/Components/Toolbar/AddDeal/Default.cshtml");
        }
    }
}
