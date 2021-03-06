using kmgiasoc.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace kmgiasoc.Permissions
{
    public class kmgiasocPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(kmgiasocPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(kmgiasocPermissions.MyPermission1, L("Permission:MyPermission1"));

            var dealCategoryPermission = myGroup.AddPermission(kmgiasocPermissions.DealCategory.Default, L("Permission:DealCategory"));
            dealCategoryPermission.AddChild(kmgiasocPermissions.DealCategory.Create, L("Permission:Create"));
            dealCategoryPermission.AddChild(kmgiasocPermissions.DealCategory.Update, L("Permission:Update"));
            dealCategoryPermission.AddChild(kmgiasocPermissions.DealCategory.Delete, L("Permission:Delete"));

            var dealPermission = myGroup.AddPermission(kmgiasocPermissions.Deal.Default, L("Permission:Deal"));
            dealPermission.AddChild(kmgiasocPermissions.Deal.Create, L("Permission:Create"));
            dealPermission.AddChild(kmgiasocPermissions.Deal.Update, L("Permission:Update"));
            dealPermission.AddChild(kmgiasocPermissions.Deal.Delete, L("Permission:Delete"));

            var countryPermission = myGroup.AddPermission(kmgiasocPermissions.Country.Default, L("Permission:Country"));
            countryPermission.AddChild(kmgiasocPermissions.Country.Create, L("Permission:Create"));
            countryPermission.AddChild(kmgiasocPermissions.Country.Update, L("Permission:Update"));
            countryPermission.AddChild(kmgiasocPermissions.Country.Delete, L("Permission:Delete"));

            var cityPermission = myGroup.AddPermission(kmgiasocPermissions.City.Default, L("Permission:City"));
            cityPermission.AddChild(kmgiasocPermissions.City.Create, L("Permission:Create"));
            cityPermission.AddChild(kmgiasocPermissions.City.Update, L("Permission:Update"));
            cityPermission.AddChild(kmgiasocPermissions.City.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<kmgiasocResource>(name);
        }
    }
}
