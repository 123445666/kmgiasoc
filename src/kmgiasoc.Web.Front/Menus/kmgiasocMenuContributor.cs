using System.Threading.Tasks;
using kmgiasoc.Permissions;
using kmgiasoc.Localization;
using kmgiasoc.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.CmsKit.Admin.Web.Menus;
using Volo.CmsKit.Public.Web.Menus;

namespace kmgiasoc.Web.Menus
{
    public class kmgiasocMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<kmgiasocResource>();

            //context.Menu.Items.Insert(
            //    0,
            //    new ApplicationMenuItem(
            //        kmgiasocMenus.Home,
            //        l["Menu:Home"],
            //        "~/",
            //        icon: "fas fa-home",
            //        order: 0
            //    )
            //);
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            administration.TryRemoveMenuItem(IdentityMenuNames.GroupName);
            administration.TryRemoveMenuItem(SettingManagementMenuNames.GroupName);
            context.Menu.TryRemoveMenuItem(CmsKitAdminMenus.GroupName);
            //foreach (var i in context.Menu.Items)
            //{
            //    context.Menu.Items.Remove(i);
            //}
        }
    }
}
