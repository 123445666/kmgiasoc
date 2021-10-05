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
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<kmgiasocResource>(name);
        }
    }
}
