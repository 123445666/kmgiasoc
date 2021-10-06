using System.Threading.Tasks;
using kmgiasoc.Permissions;
using kmgiasoc.Localization;
using kmgiasoc.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

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
            
            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
            if (await context.IsGrantedAsync(kmgiasocPermissions.DealCategory.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(kmgiasocMenus.DealCategory, l["Menu:DealCategory"], "/DealCategories/DealCategory")
                );
            }
            if (await context.IsGrantedAsync(kmgiasocPermissions.Deal.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(kmgiasocMenus.Deal, l["Menu:Deal"], "/Deals/Deal")
                );
            }
        }
    }
}
